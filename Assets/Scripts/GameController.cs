using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int point
    {
        private set; get;
    }

    public bool isPlaying
    {
        private set; get;
    }

    public Bird bird;

    public ChallengeGenerator challengeGenerator;

    public int generatingTime;

    private UIController uIController;

    public EasterEggController easterEggController
    {
        get; private set;
    }

    public LyricController lyricController
    {
        get; private set;
    }

    private Vector3 birdDefaultPosition;

    protected void Awake()
    {
        //set UI Controller
        uIController = GetComponent<UIController>();
        uIController.gameController = this;

        challengeGenerator.gameController = this;

        bird.gameController = this;

        easterEggController = GetComponent<EasterEggController>();
        if (easterEggController != null)
        {
            Debug.Log("EASTER EGG CONTROLLER DETECTED!!!");
            easterEggController.gameController = this;
            easterEggController.Awake();
        }

        lyricController = GetComponent<LyricController>();
        if (lyricController != null)
        {
            Debug.Log("LYRIC CONTROLLER DETECTED!!!");
            lyricController.gameController = this;
            lyricController.Awake();
        }
    }

    void Start()
    {
        Time.timeScale = 0;
        isPlaying = false;
        bird.gameObject.SetActive(false);
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        isPlaying = true;
        point = 0;
        SetTextPoint();

        //set UI
        uIController.GameStart();
        //set bird
        bird.transform.position = birdDefaultPosition;
        bird.gameObject.SetActive(true);

        //set generator
        challengeGenerator.InitGenerator();
        challengeGenerator.StartGenerator();

    }

    public void GameOver()
    {
        Debug.Log("GameController : GAME OVER, point = " + point);
        Time.timeScale = 0;
        isPlaying = false;

        challengeGenerator.StopAllCoroutines();

        uIController.GameOver(point);
    }

    public void AddPoint(GameObject obj)
    {
        point++;
        Debug.Log("GameController : add point = " + point);
        obj.SetActive(false);
        SetTextPoint();

        if (easterEggController != null && easterEggController.isEasterEgg())
        {
            challengeGenerator.StopAllCoroutines();
            easterEggController.easterEggGenerator.StartGenerator();
        }

        if (lyricController != null && lyricController.LyricTrigger())
        {
            lyricController.lyricGenerator.StartGenerator();
        }
    }

    private void SetTextPoint()
    {
        uIController.SetPoint(point);
    }

    public void SetBirdDefaultPosition(Vector3 position)
    {
        this.birdDefaultPosition = position;
        Debug.Log("set bird default position to = " + this.birdDefaultPosition);
    }

    public bool isEasterEgg()
    {
        bool res = easterEggController != null ? easterEggController.isEasterEgg() : false;
        Debug.Log("GameController : isEasterEgg ? " + res);

        return res;
    }
}
