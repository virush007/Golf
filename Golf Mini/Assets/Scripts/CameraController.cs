using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float turnSpeed = 4.0f;

    Vector3 mouseOrigin;
    bool isRotating;
    Vector3 moveCheck;

    float prevsDistance;
    float currDistance;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GlobalValues.cameraControlling)
        {
            mouseOrigin = Input.mousePosition;
            moveCheck = mouseOrigin;
            prevsDistance = Vector3.Distance(mouseOrigin, Input.mousePosition);
            isRotating = true;

        }
        if (!Input.GetMouseButton(0))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            //transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }
    }
}
