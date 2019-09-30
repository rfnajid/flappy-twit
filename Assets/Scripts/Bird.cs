using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GameController))]
public class Bird : MonoBehaviour
{

    public GameController gameController;

    public float downSpeed=1f;

    public int upCount = 10;


    float upSpeed;
    int upCounter=0;
    bool isUp =false;

    Rigidbody2D rb;

    // Start is called before the first frame update
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upSpeed = downSpeed * 2;
    }

    void FixedUpdate()
    {
        Vector3 direction = -transform.up * downSpeed;
        if(isUp){
            upCounter++;
            direction = transform.up * upSpeed;
            if(upCounter>upCount){
                upCounter =0;
                isUp = false;
            }
        }
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Bird hit "+other.gameObject.name);
        switch(other.gameObject.tag){
            case "Wall":
                gameController.gameOver();
            break;
            case "Land":
                this.Up();
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Bird triggered "+other.gameObject.name);
        switch(other.gameObject.tag){
            case "Point":
                gameController.addPoint(other.gameObject);
            break;
        }
    }

    public void Up(){
        isUp = true;
    }
}
