using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasterEggController : MonoBehaviour
{

    public GameController gameController
    {
        set; private get;
    }

    public int easterEggGeneratingTime;
    public int scoreToEasterEgg;

    [SerializeField]
    private TextMeshPro easterEgg;
    [SerializeField]
    private string easterEggMessage;

    public EasterEggGenerator easterEggGenerator;

    public void Awake()
    {
        easterEggGenerator.easterEggController = this;
        easterEggGenerator.gameController = gameController;

        // set easter egg message
        easterEgg.text = easterEggMessage;
    }

    public bool isEasterEgg()
    {
        return gameController.point >= scoreToEasterEgg;
    }

}