using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed = 5f;

    // Start is called before the first frame update
     void Start()
    {
    }

    void FixedUpdate()
    {
        Vector3 direction = -transform.right * speed;

        transform.position = transform.position + direction * Time.fixedDeltaTime;
    }
}
