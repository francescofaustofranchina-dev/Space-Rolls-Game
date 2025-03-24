using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour{

    [SerializeField] float rotationFactorPerFrame;

    private DiceFace[] faces;

    private Color[] colors;

    private int lastColorIndex;
    
    private Vector3 eulers;

    private void OnEnable(){
        GameManager.PhaseOneStarted += HandleRotation;
    }

    private void OnDisable(){
        GameManager.PhaseOneStarted -= HandleRotation;
    }

    // Start is called before the first frame update
    private void Start(){
        colors = GameManager.instance.GetColors();
        InitializeFaces();

        int index = UnityEngine.Random.Range(0, faces.Length);
        transform.rotation = faces[index].GetRotation();

        lastColorIndex = -1;
    }

	//metodi di setup

	private void InitializeFaces(){
        //l'indice di ogni faccia corrisponde all'id
        //dato al colore corrispondente
        Quaternion[] directions = new Quaternion[6];
        directions[0] = new Quaternion(0f, 1f, 0f, 0f); //blu        
        directions[1] = new Quaternion(-0.5f, -0.5f, -0.5f, 0.5f); //arancione
        directions[2] = new Quaternion(0f, 0f, 0f, 1f); //verde        
        directions[3] = new Quaternion(0.5f, -0.5f, -0.5f, -0.5f); //rosso
        directions[4] = new Quaternion(0.70711f, 0f, 0f, -0.70711f); //fucsia
        directions[5] = new Quaternion(0.70711f, 0f, 0f, 0.70711f); //giallo

        faces = new DiceFace[6];
        for(int i = 0; i < 6; ++i){
            faces[i] = new DiceFace(directions[i], colors[i]);
        }
    }

    //metodi di uso

    public void HandleRotation(float rotationEffectTime){
        StartCoroutine(PlayRandomRotationEffect(rotationEffectTime));
    }

    private IEnumerator PlayRandomRotationEffect(float rotationEffectTime){        
        if(UnityEngine.Random.Range(0, 1) == 0)
            eulers = Vector3.up;
        else
            eulers = Vector3.down;

        while(rotationEffectTime > 0f){
            yield return new WaitForSeconds(0f);    //avvia subito l'effetto            
            eulers.x = UnityEngine.Random.Range(-1, 1);
            eulers.z = UnityEngine.Random.Range(-1, 1);
            transform.Rotate(eulers, rotationFactorPerFrame * Time.deltaTime);
            rotationEffectTime -= Time.deltaTime;
        }
        StartCoroutine(Roll());
    }

    private IEnumerator Roll(){
        int index;
        do{
            index = UnityEngine.Random.Range(0, faces.Length);
        }
        while(index == lastColorIndex);
        
        GameManager.instance.actualDiceColor = colors[index];
        var face = faces[GameManager.instance.actualDiceColor.GetId()];
        Quaternion targetRotation = face.GetRotation();
        while(transform.rotation != targetRotation){
            yield return new WaitForSeconds(0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

        lastColorIndex = index;
    }    
}