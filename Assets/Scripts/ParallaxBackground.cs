using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float offset = 0f;

    private Vector2 startPosition;

    private float newPosition;

    void Start(){
        startPosition = transform.position;
    }

    void Update(){
        newPosition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPosition + Vector2.right * newPosition;
    }

}
