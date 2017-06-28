using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class ShipMovement : MonoBehaviour {
    public Transform camera;
    public GameObject GVREditorEmulator;
    Quaternion prevRotation;
    float speed = 30f;
    bool isTurnLeft;
    bool isTurnRight;
    bool isTurnUp;
    bool isTurnDown;
    bool isStart;
    Vector3 targetPos;
    void Start()
    {
        prevRotation = camera.rotation;
        isTurnLeft = false;
        isTurnRight = false;
        isTurnUp = false;
        isTurnDown = false;
        isStart = false;
        transform.position = new Vector3(0, 0, -2);
        targetPos = new Vector3(0, 0, 5.08f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStart)
        {
            float step = Time.deltaTime * 2;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if (transform.position == targetPos)
                isStart = true;
        }
        else
        {
            GVREditorEmulator.active = true;
            if (camera.rotation != prevRotation)
            {
                if (prevRotation.eulerAngles.y < camera.eulerAngles.y)
                {
                    //print("turn right");
                    isTurnRight = true;
                }
                else if (prevRotation.eulerAngles.y > camera.eulerAngles.y)
                {
                    //print("turn left");
                    isTurnLeft = true;
                }
                //if(prevRotation.eulerAngles.x > camera.eulerAngles.x)
                //{
                //    //print("up");    
                //    isTurnUp = true;
                //}
                //else if (prevRotation.eulerAngles.x < camera.eulerAngles.x)
                //{
                //    //print("down");
                //    isTurnDown = true;
                //}
            }
            else
            {
                // print("normal");
                isTurnLeft = false;
                isTurnRight = false;
                isTurnUp = false;
                isTurnDown = false;
            }

            Turning(isTurnLeft, isTurnRight, isTurnUp, isTurnDown);
            prevRotation = camera.rotation;
        }
    }
    void Turning(bool isLeft, bool isRight, bool isUp, bool isDown)
    {
        print("Angle: " + transform.eulerAngles.z);
        if(isLeft && !isRight)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime *speed);
        }
        if(!isLeft && isRight)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }
        //if (isUp && !isDown)
        //{
        //    transform.Rotate(Vector3.left * Time.deltaTime * speed);
        //}
        //if (!isUp && isDown)
        //{
        //    transform.Rotate(Vector3.right * Time.deltaTime * speed);
        //}
        if (!isLeft && !isRight)
        {
            if (transform.eulerAngles.z < 359 && transform.eulerAngles.z >180)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);
            }
            else if (transform.eulerAngles.z > 1 && transform.eulerAngles.z < 180)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * speed);
            }
            //else if(transform.eulerAngles.z >= 359 || transform.eulerAngles.z <= 1)
            //{
            //    transform.eulerAngles.Set(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            //}
            //if (transform.eulerAngles.x < 360 && transform.eulerAngles.x > 180)
            //{
            //    //if (transform.eulerAngles.x > 359)
            //    //    transform.eulerAngles.Set(0, transform.eulerAngles.y, transform.eulerAngles.z);
            //    //else
            //        transform.Rotate(Vector3.right * Time.deltaTime * speed);
            //}
            //else if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 180)
            //{
            //    transform.Rotate(Vector3.left * Time.deltaTime * speed);
            //}
        }
    }
}
