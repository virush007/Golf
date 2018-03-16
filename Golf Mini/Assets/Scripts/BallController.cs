using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public float speed = 1f;
    public Image powerBar;
    bool high = true;


   

    Vector3 prevs;

    Vector3 movePosition;
    void changePower()
    {

        if (high)
        {
            speed+=100f;
        }
        else
        {
            speed-=100f;
        }
        if (speed == 10000)
        {
            high = false;
        }
        if (speed == 100)
        {
            high = true;
        }
        powerBar.fillAmount = speed/10000;
    }
    // Use this for initialization
    void Start()
    {
        prevs = transform.position;
        GlobalValues.hit = false;
        powerBar.fillAmount = 0;
        GlobalValues.gameStart = false;
        GlobalValues.isGameOver = false;
        //InvokeRepeating("changePower", 0.01f, 0.01f);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (GlobalValues.isGameOver) {
            return;
        }
        else if (Vector3.Distance(prevs, transform.position) < 0.01 && !GlobalValues.gameStart)
        {
            resetValues();
            Debug.Log("Entered..........");
        }
        else {
            Debug.Log("Exit..........");
        }
        prevs = transform.position;
    }
    void resetValues() {
        GlobalValues.gameStart = true;
        GlobalValues.cameraControlling = true;
        GlobalValues.hit = false;
        GlobalValues.powerDisplay = false;
        GlobalValues.hit = false;
        high = true;
        speed = 0;
        //GlobalValues.gameStart = false;
    }
    public void hitBall() {
        if (GlobalValues.isGameOver) {
            return;
        }
        else if (GlobalValues.gameStart) {
            if (!GlobalValues.powerDisplay)
            {
                InvokeRepeating("changePower", 0.01f, 0.01f);
                GlobalValues.powerDisplay = true;
                GlobalValues.hit = true;
            }
            else if(GlobalValues.hit)
            {
                GlobalValues.hit = false;
                GlobalValues.cameraControlling = false;
                movePosition = Camera.main.transform.TransformDirection(transform.forward);
                GetComponent<Rigidbody>().AddForce(movePosition * speed * Time.deltaTime * 100);
                GlobalValues.gameStart = false;
                CancelInvoke();
            }
        }
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Water") {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (col.gameObject.tag == "Hole") {
            Invoke("gameOver", 2f);
        }
    }

    void gameOver() {
        Application.LoadLevel(Application.loadedLevel);
    }

}
