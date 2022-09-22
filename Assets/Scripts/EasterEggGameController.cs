using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasterEggGameController : GameController
{
    public int easterEggGeneratingTime;
    public int scoreToEasterEgg;

    [SerializeField]
    private TextMeshPro easterEgg;
    [SerializeField]
    private string easterEggMessage;

    public EasterEggGenerator easterEggGenerator;

    protected void Awake()
    {
        base.Awake();

        //set generator
        easterEggGenerator.gameController = this;

        // set easter egg message
        easterEgg.text = easterEggMessage;
    }

    public bool isEasterEgg()
    {
        return point >= scoreToEasterEgg;
    }

    public void GameOver()
    {
        base.GameOver();

        easterEggGenerator.StopAllCoroutines();
    }
}