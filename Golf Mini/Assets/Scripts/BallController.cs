using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed =100f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
            GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime);
        }
	}
}
