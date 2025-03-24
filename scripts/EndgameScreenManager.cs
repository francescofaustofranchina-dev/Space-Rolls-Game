using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndgameScreenManager : MonoBehaviour{

    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text recordText;
    [SerializeField] TMP_Text messageText;

    private float gameTime, recordTime;

    //METODI DI AVVIO

	private void OnEnable(){
        recordTime = JSONSaving.instance.LoadData().GetRecordTime();
        gameTime = GameTimer.instance.GetGameTime();
        HandleText();                   
	}

    //METODI DI USO

    private void HandleText(){        
        timeText.text = gameTime.ToString("0.00");

        if(recordTime == -1f){
            recordText.text = "NULL";
            JSONSaving.instance.SaveData(gameTime);
            messageText.text = "EXCELLENT! YOU HAVE SET A NEW \nPERSONAL RECORD!";
        }
        else{
            recordText.text = recordTime.ToString("0.00");
            if(float.Parse(timeText.text) < float.Parse(recordText.text)){
                JSONSaving.instance.SaveData(gameTime);
                messageText.text = "EXCELLENT! YOU HAVE SET A NEW \nPERSONAL RECORD!";
            }
            else
                messageText.text = "YOUR CURRENT TIME IS HIGHER THAN YOUR PESONAL BEST. \nYOU CAN STILL DO BETTER."; 
        }
    }
}