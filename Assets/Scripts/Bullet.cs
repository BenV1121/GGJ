using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 17;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, force * Time.deltaTime, 0);
	}
}
