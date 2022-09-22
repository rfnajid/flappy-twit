using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeGenerator : Generator
{
    public Mover[] walls;

    public GameController gameController
    {
        set; protected get;
    }

    public override void Awake()
    {
        InitGenerator();
    }

    public override void InitGenerator()
    {
        foreach (Mover mover in walls)
        {
            mover.transform.parent = this.transform;
            mover.transform.position = new Vector3(
                transform.position.x,
                mover.transform.position.y,
                0);
            mover.gameObject.SetActive(false);
        }
    }

    public override void StartGenerator()
    {
        Debug.Log("Generator Started");
        StartCoroutine(Generating());
    }

    protected override IEnumerator Generating()
    {
        int generatingTime = 0;
        while (gameController.isPlaying && isOn)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(0, walls.Length);
            nextObject = walls[randomNumber];
            // set active heart 
            nextObject.transform.GetChild(0).gameObject.SetActive(true);
            generatingTime = gameController.generatingTime;
            yield return AfterGenerating(generatingTime);
        }
    }
}
