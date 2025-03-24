using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour{

    //singleton pattern
    public static PlayerStatus instance;

    private CharacterController controller;

    private int collectiblesTaken;
    private Platform lastOccupiedPlatform;

    //events
    public delegate void PlayerDieEvent();
    public static event PlayerDieEvent PlayerDied;
    public delegate void UnlockEndingEvent();
    public static event UnlockEndingEvent AllCollectiblesTaken;
    public static event UnlockEndingEvent FallenIntoTheSpace; 

    //METODI DI AVVIO

    private void Awake(){
        if(instance != null)
            Destroy(this);
        else
            instance = this;          
    }

    private void OnEnable(){
        PlayerInteraction.PlayerCollidedWithPlatform += SetLastOccupiedPlatform;
        Collectible.CollectibleTaken += IncreaseCollectiblesTaken;
    }

    private void OnDisable(){
        PlayerInteraction.PlayerCollidedWithPlatform -= SetLastOccupiedPlatform;
        Collectible.CollectibleTaken -= IncreaseCollectiblesTaken;
    }

    private void Start(){
        collectiblesTaken = 0;
        controller = GetComponent<CharacterController>();
    }

    private void Update(){
        if(transform.position.y <= -70f && !GameManager.instance.HasGameEnded()){
            GameManager.instance.isInputOn = false;
            GameManager.instance.EndGame();
            if(FallenIntoTheSpace != null)
                FallenIntoTheSpace();            
        }
    }

    //METODI LEGATI AI CAMBI DI STATO

    public void Die(){
        GameManager.instance.isInputOn = false;
        GameManager.instance.EndGame();
        if(PlayerDied != null){
            PlayerDied();
        }            
    }

    private void IncreaseCollectiblesTaken(){
        ++collectiblesTaken;
        if(collectiblesTaken == CollectibleManager.instance.GetMaxCollectiblesPerGame()){
            GameManager.instance.EndGame();
            if(AllCollectiblesTaken != null)
                AllCollectiblesTaken();            
        }
    }

    //SETTER

    private void SetLastOccupiedPlatform(Platform platform){
        lastOccupiedPlatform = platform;
    }

    //GETTER

    public Platform GetLastOccupiedPlatform(){
        return lastOccupiedPlatform;
    }

    //ho messo la seconda condizione per semplificare il tutto dato che se
    //il giocatore è sulla piattaforma ha un altezza nello spazio superiore a 0
    public bool IsOnCheckpoint(){
        return controller.isGrounded && (transform.position.y > 0f);
    }
}