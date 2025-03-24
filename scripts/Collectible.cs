using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{

    //events
    public delegate void CollectibleInteractionEvent();
    public static event CollectibleInteractionEvent CollectibleTaken;

	private void OnTriggerEnter(Collider other){
		gameObject.SetActive(false);
        UpdateCollectiblesTakenValue();
	}

    private void UpdateCollectiblesTakenValue(){
        if(CollectibleTaken != null)
            CollectibleTaken();
    }
}
