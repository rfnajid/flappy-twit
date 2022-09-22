using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Generator : MonoBehaviour
{
    public bool isOn;
    protected Mover nextObject;

    public abstract void Awake();
    public abstract void InitGenerator();
    public abstract void StartGenerator();

    protected abstract IEnumerator Generating();

    protected IEnumerator AfterGenerating(int generatingTime)
    {
        Debug.Log("Generating : " + nextObject.name);
        nextObject.gameObject.SetActive(true);
        nextObject.transform.position = new Vector3(
            transform.position.x,
            nextObject.transform.position.y,
            0);

        yield return new WaitForSeconds(generatingTime);
    }
}
