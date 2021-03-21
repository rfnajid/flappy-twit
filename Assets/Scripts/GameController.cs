using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int point {
        private set; get;
    }

    public bool isPlaying {
        private set; get;
    }

    public Bird bird {
        set; private get;
    }

    public Generator generator;
    public int generatingTime;

    private UIController uIController;

    public int easterEggGeneratingTime;
    public int pointToEasterEgg;

    private Vector3 birdDefaultPosition;

    void Awake(){
        //set generator
        generator.gameController = this;
        //set UI Controller
        uIController = GetComponent<UIController>();
        uIController.gameController = this;
    }

    void Start(){
        Time.timeScale = 0;
        isPlaying = false;
        bird.gameObject.SetActive(false);
    }

    public void gameStart(){
        Time.timeScale = 1;
        isPlaying = true;
        point = 0;
        setTextPoint();

        //set UI
        uIController.gameStart();
        //set bird
        bird.transform.position = birdDefaultPosition;
        bird.gameObject.SetActive(true);

        //set generator
        generator.initGenerator();
        generator.startGenerator();

    }

    public void gameOver(){
        Debug.Log("GameController : GAME OVER, point = "+point);
        Time.timeScale = 0;
        isPlaying = false;

        generator.stopAllCoroutines();

        uIController.gameOver(point);
    }

    public void addPoint(GameObject obj){
        point++;
        Debug.Log("GameController : add point = "+point);
        obj.SetActive(false);
        setTextPoint();
    }

    private void setTextPoint(){
        uIController.setPoint(point);
    }

    public bool isEasterEgg(){
        return point >= pointToEasterEgg;
    }

    public void setBirdDefaultPosition(Vector3 position){
        this.birdDefaultPosition = position;
        Debug.Log("set bird default position to = "+ this.birdDefaultPosition);
    }
}
