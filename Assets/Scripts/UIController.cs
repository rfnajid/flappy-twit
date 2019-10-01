using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject UIStart;
    public GameObject UIGamePlay;
    public GameObject UIEnd;
    private GameController gameController;
    private Text textPoint;

    private void Awake() {
        textPoint = UIGamePlay.transform.GetChild(UIGamePlay.transform.childCount-1)
            .GetChild(1).GetComponent<Text>();
        UIGamePlay.SetActive(false);
        UIEnd.SetActive(false);
        UIStart.SetActive(true);
    }

    public void setGameController(GameController gameController){
        this.gameController = gameController;
    }

    public void setPoint(int point){
        textPoint.text = point+"";
    }

    public void gameStart(){
        UIEnd.SetActive(false);
        UIStart.SetActive(false);
        UIGamePlay.SetActive(true);
    }

    public void gameOver(int point){

        Text finalScore = UIEnd.transform.GetChild(UIEnd.transform.childCount-1).GetComponent<Text>();
        finalScore.text = "score : "+point;

        UIStart.SetActive(false);
        UIGamePlay.SetActive(false);
        UIEnd.SetActive(true);
    }

}
