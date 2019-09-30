using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text textPoint;

    public int point {
        private set; get;
    }

    public Generator generator;
    public int generatingTime;
    public int easterEggGeneratingTiem;

    public int pointToEasterEgg;

    void Awake(){
        generator.setGameController(this);
        textPoint.text="0";
    }

    void Start(){
        generator.StartGenerator();
    }

    public void addPoint(GameObject obj){
        point++;
        Debug.Log("GameController : add point = "+point);
        obj.SetActive(false);
        textPoint.text = point+"";
    }

    public void gameOver(){
        Debug.Log("GameController : GAME OVER, point = "+point);
        textPoint.text = 0+"";
    }

    public bool isEasterEgg(){
        return point >= pointToEasterEgg;
    }
}
