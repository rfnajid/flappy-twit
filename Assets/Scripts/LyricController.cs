using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LyricController : MonoBehaviour
{

    public GameController gameController
    {
        set; private get;
    }

    public int lyricGeneratingTime;
    public int scoreToLyric;
    public LyricGenerator lyricGenerator;

    public void Awake()
    {
        lyricGenerator.lyricController = this;
        lyricGenerator.gameController = gameController;
        Debug.Log("lyric controller. Is game controller not null ? " + (gameController != null));
    }

    public bool LyricTrigger()
    {
        return gameController.point == scoreToLyric;
    }

}