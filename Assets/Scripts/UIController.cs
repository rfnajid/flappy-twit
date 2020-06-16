using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject uiStart;
    public GameObject uiGamePlay;
    public GameObject uiEnd;
    public GameController gameController{
        set; private get;
    }
    private Text textPoint;

    private void Awake() {
        textPoint = uiGamePlay.transform.GetChild(uiGamePlay.transform.childCount-1)
            .GetChild(1).GetComponent<Text>();
        uiGamePlay.SetActive(false);
        uiEnd.SetActive(false);
        uiStart.SetActive(true);
    }

    public void setPoint(int point){
        textPoint.text = point+"";
    }

    public void gameStart(){
        uiEnd.SetActive(false);
        uiStart.SetActive(false);
        uiGamePlay.SetActive(true);
    }

    public void gameOver(int point){

        Text finalScore = uiEnd.transform.GetChild(uiEnd.transform.childCount-1).GetComponent<Text>();
        finalScore.text = "score : "+point;

        uiStart.SetActive(false);
        uiGamePlay.SetActive(false);
        uiEnd.SetActive(true);
    }

}
