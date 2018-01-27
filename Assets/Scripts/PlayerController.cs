using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movement = 5.0f;
    float xMove;
    float yMove;

	// Update is called once per frame
	void Update ()
    {
        xMove = Input.GetAxis("Horizontal") * movement * Time.deltaTime;
        yMove = Input.GetAxis("Vertical")   * movement * Time.deltaTime;

        transform.Translate(xMove, yMove, 0);

        if(transform.position.x >= 13)
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
}
