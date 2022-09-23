using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggGenerator : Generator
{
    public Mover easterEgg;

    public EasterEggController easterEggController
    {
        set; private get;
    }

    public override void Awake()
    {
        InitGenerator();
    }

    public override void InitGenerator()
    {
        easterEgg.transform.parent = this.transform;
        easterEgg.transform.position = new Vector3(
                transform.position.x,
                easterEgg.transform.position.y,
                0);
        easterEgg.gameObject.SetActive(false);
    }

    public override void StartGenerator()
    {
        Debug.Log("Generator Started");
        StartCoroutine(Generating());
    }

    protected override IEnumerator Generating()
    {
        int generatingTime = 0;
        while (isOn || easterEggController.isEasterEgg())
        {
            nextObject = easterEgg;
            generatingTime = easterEggController.easterEggGeneratingTime;
            yield return AfterGenerating(generatingTime);
        }
    }
}
