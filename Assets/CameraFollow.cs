using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Object to follow
    public GameObject ball;

    // Distance between camera and ball
    Vector3 offset;

    // Rate that camera updates position
    public float lerpRate;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Substract pos of camera to ball to get consistent distance
        offset = ball.transform.position - transform.position;

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver) {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;

        // Transition from vectors smoothly
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
