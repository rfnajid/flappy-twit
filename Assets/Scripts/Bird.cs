using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{

    public GameController gameController;
    public float downSpeed=1f;
    public int upCount = 10;
    public AudioClip audioWing;
    public AudioClip audioPoint;
    public AudioClip audioDead;

    float upSpeed;
    int upCounter=0;
    bool isUp =false;
    AudioSource audioSource;
    Rigidbody2D rb;

    void Awake(){
        this.gameController.bird = this;
        this.gameController.setBirdDefaultPosition(transform.position);

        audioSource = GetComponent<AudioSource>();
    }

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
                audioSource.PlayOneShot(audioDead);
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
                audioSource.PlayOneShot(audioPoint);
                gameController.addPoint(other.gameObject);
            break;
        }
    }

    public void Up(){
        isUp = true;
        audioSource.PlayOneShot(audioWing);
    }
}
