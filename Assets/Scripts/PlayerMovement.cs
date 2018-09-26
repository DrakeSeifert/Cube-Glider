//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 100f;

    bool moveRight = false;
    bool moveLeft = false;

    // Use this for initialization
    //void Start()
    //{
    //    //rb.useGravity = false;
    //}

    // Update is called once per frame
    void FixedUpdate () {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            moveRight = true;
        }
        else {
            moveRight = false;
        }
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if(moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //If player falls off platform
        if(rb.position.x < -8 || rb.position.x > 8)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
