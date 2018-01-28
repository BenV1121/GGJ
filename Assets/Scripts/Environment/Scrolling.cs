using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    float move = -.5f;
    public bool upsideDown = false;
    public bool rotating = false;
	
	// Update is called once per frame
	void Update ()
    {
        if (!upsideDown)
        {
            transform.Translate(0, 0, move * Time.deltaTime);
        }
        else if (upsideDown)
        {
            transform.Translate(0, 0, -move * Time.deltaTime);
        }

        if (transform.position.z <= -65)
        {
            transform.position = new Vector3(-2, transform.position.y, 65);
            transform.rotation = new Quaternion(transform.rotation.x, -180, transform.rotation.z, 0);
            upsideDown = true;
        }
        if (transform.position.z <= -25 && upsideDown == true)
        {
            transform.position = new Vector3(2, transform.position.y, 25);
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0);
            upsideDown = false;
        }
    }
}
