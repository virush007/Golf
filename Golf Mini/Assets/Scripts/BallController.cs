using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public float speed = 1f;
    public Image powerBar;
    bool high = false;

    Vector3 movePosition;
    void changePower()
    {

        if (high)
        {
            speed++;
        }
        else
        {
            speed--;
        }
        if (speed == 100)
        {
            high = false;
        }
        if (speed == 0)
        {
            high = true;
        }
        powerBar.fillAmount = speed/100;
    }


    // Use this for initialization
    void Start()
    {
        powerBar.fillAmount = 0;
        //InvokeRepeating("changePower", 0.01f, 0.01f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            movePosition = Camera.main.transform.TransformDirection(transform.forward);
            GetComponent<Rigidbody>().AddForce(movePosition * speed * Time.deltaTime*100);
            //GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime *10;
        }
    }


    



}
