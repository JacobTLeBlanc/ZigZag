using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    bool started;
    bool gameOver;

    Rigidbody rb;

    void Awake() {
        // Get access to rigidbody component of ball
        rb = GetComponent<Rigidbody> ();

    }

    // Start is called before the first frame update
    void Start()
    {
        // Init boolean
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game started
        if (!started) {
            if (Input.GetMouseButtonDown(0)) {
                // Velocity of ball
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        // Ray to check if ball is above platform
        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
            
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }

        

        // Check input
        if (Input.GetMouseButtonDown(0) && !gameOver) {
            SwitchDirection();
        }
    }

    void SwitchDirection() {
        // Check which direction ball is going in already and switch
        if (rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0 ,0);
        } else if(rb.velocity.x > 0) {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
