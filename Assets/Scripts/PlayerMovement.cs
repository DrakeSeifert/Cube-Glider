//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public GameManager gameManager;

    float forwardForce = 5000f;
    float sidewaysForce = 80f;

    bool moveRight = false;
    bool moveLeft = false;
    bool isRewinding = false;
    bool playerIsPaused = false;

    int recordPositionCounter = 0;
    int RECORD_MAX = 5;

    List<Vector3> positions;

    void Start()
    {
        positions = new List<Vector3>();
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        //isRewinding = false;
        playerIsPaused = true;
        rb.isKinematic = false;
    }

    //Save positions to rewind
    void Record()
    {
        //Record every other position
        if (recordPositionCounter == RECORD_MAX - 1)
        {
            positions.Insert(0, transform.position);
            recordPositionCounter = 0;
        }
        else
        {
            recordPositionCounter++;
        }
    }

    //Rewind player
    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void FixedUpdate () {

        if (isRewinding && !playerIsPaused)
        {
            Rewind();
        }
        else if (!isRewinding && !playerIsPaused)
        {
            Record();

            //Move block forward
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            //Respond to user input
            if (Input.GetKey("d"))
            {
                moveRight = true;
            }
            else
            {
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

            if (moveRight)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (moveLeft)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        else
        {
            gameManager.startCompleteLevelAnimation();
        }

        //End game if player falls off platform
        if(rb.position.x < -8 || rb.position.x > 8)
        {
            FindObjectOfType<GameManager>().EndGame("FellOffEdge");
        }
    }
}
