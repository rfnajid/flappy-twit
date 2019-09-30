using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{


    public Mover [] walls;

    public Mover easterEgg;

    GameController gameController;
    Mover nextObject;

    void Awake(){
        foreach(Mover mover in walls){
            mover.transform.parent = this.transform;
        }
        easterEgg.transform.parent = this.transform;
    }

    public void setGameController(GameController gameController){
        this.gameController = gameController;
    }

    public void StartGenerator(){
        Debug.Log("Generator Started");
        StartCoroutine(Generating());
    }

    IEnumerator Generating(){
        int generatingTime =0;
        while(true){
            if(gameController.isEasterEgg()){
                nextObject = easterEgg;
                generatingTime = gameController.easterEggGeneratingTiem;
            }
            else{
                System.Random random = new System.Random();
                int randomNumber  = random.Next(0, walls.Length);
                nextObject = walls[randomNumber];
                nextObject.transform.GetChild(0).gameObject.SetActive(true);
                generatingTime = gameController.generatingTime;
            }
            Debug.Log("Generating : "+nextObject.name);
            nextObject.gameObject.SetActive(true);
            nextObject.transform.position = new Vector3(
                transform.position.x,
                nextObject.transform.position.y,
                0);

            yield return new WaitForSeconds(generatingTime);
        }
    }

}
