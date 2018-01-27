﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movement = 5.0f; // Movement speed
    float xMove; //X-Axis Movment.
    float yMove; //Y-Axis Movment.

    public bool speedIsPoweredUp;
    public float speedUpTimer = 10;

    void Start()
    {
        speedIsPoweredUp = false;
    }

    // Update is called once per frame
    void Update ()
    {
        xMove = Input.GetAxis("Horizontal") * movement * Time.deltaTime; // Makes xMove move with movement speed times Time.deltaTime using the input (A and D).
        yMove = Input.GetAxis("Vertical")   * movement * Time.deltaTime; // Makes yMove move with movement speed times Time.deltaTime using the input (W and S).

        if(speedIsPoweredUp)
        {
            transform.Translate(xMove * 3, yMove * 3, 0); // If speedIsPoweredUp is set to true, then the movment will triple
            speedUpTimer -= 1 * Time.deltaTime;

            if (speedUpTimer <= 0)
            {
                speedIsPoweredUp = false;
                speedUpTimer = 10;
            }
        }
        else
            transform.Translate(xMove, yMove, 0); // If not, then movement will be normal.

        // IF the player is in this certain posiion or more/less than it, the player stay at that certain position, preventing it to go further out of the boundary.
        if (transform.position.x >= 13)
        {
            transform.position = new Vector3(13, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -13)
        {
            transform.position = new Vector3(-13, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= 8.5)
        {
            transform.position = new Vector3(transform.position.x, 8.5f, transform.position.z);
        }
        if (transform.position.y <= -6.5)
        {
            transform.position = new Vector3(transform.position.x, -6.5f, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "yes")
        {
            speedIsPoweredUp = true;
        }
    }
}
