using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyricGenerator : Generator
{
    public GameObject lyricsContainer;
    private Mover[] lyrics;

    public LyricController lyricController
    {
        set; private get;
    }

    public override void Awake()
    {
        InitGenerator();
    }

    public override void InitGenerator()
    {
        lyrics = lyricsContainer.GetComponentsInChildren<Mover>();
        foreach (Mover mover in lyrics)
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
        Debug.Log("Lyric Generator Started : ");
        isOn = true;
        StartCoroutine(Generating());
    }

    protected override IEnumerator Generating()
    {
        int index = 0;
        Debug.Log("Is game controller not null ? " + (gameController != null));
        while (gameController.isPlaying && isOn)
        {
            isOn = isOn && lyrics.Length > index;
            nextObject = lyrics[index];

            index++;
            yield return AfterGenerating(lyricController.lyricGeneratingTime);
        }
    }
}
