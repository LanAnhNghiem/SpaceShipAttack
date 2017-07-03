using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class ShipMovement : MonoBehaviour {
    public Transform camera;
    public GameObject cameraContainer;
    public GameObject GVREditorEmulator;
    public bool isStart;
    Quaternion prevRotation;
    CameraController camControl;
    ShipController shipControl;
    float speed = 30f;
    Vector3 angleX;
    Vector3 angleY;
    Vector3 targetPos;
    void Start()
    {
        prevRotation = camera.rotation;
        isStart = false;
        transform.position = new Vector3(0, 4f, 3.08f);
        targetPos = new Vector3(0, -1, 3.08f);
        camControl = cameraContainer.GetComponent<CameraController>();
        camControl.enabled = false;
        shipControl = GetComponent<ShipController>();
        shipControl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
        {
            float step = Time.deltaTime * 2;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if (transform.position == targetPos)
            {
                isStart = true;
                camControl.enabled = true;
            }
        }
        else
        {
            shipControl.enabled = true;
            GVREditorEmulator.active = true;
            Turning();
        }
    }
    
    void Turning()
    {
        if (Input.GetAxis("Horizontal") != -0.5 || Input.GetAxis("Vertical") != -0.5)
        {
            if (Input.GetAxis("Vertical") == 0.5)
            {
                angleY = Vector3.right * Time.deltaTime * speed;
                transform.Rotate(angleY);//right
            }
            else if (Input.GetAxis("Vertical") > 0.5)
            {
                angleY = Vector3.left * Time.deltaTime * speed;
                transform.Rotate(angleY); //left
            }
            if (Input.GetAxis("Horizontal") == 0.5)
            {
                angleX = Vector3.back * Time.deltaTime * speed;
                transform.Rotate(angleX); //down
            }
            else if (Input.GetAxis("Horizontal") > 0.5)
            {
                angleX = Vector3.forward * Time.deltaTime * speed;
                transform.Rotate(angleX);//up
            }
        }
        if (Input.GetAxis("Vertical") == -0.5)
        {
            //float angle = Vector3.AngleBetween(angleY, Vector3.zero);
            if (transform.eulerAngles.x < 359 && transform.eulerAngles.x > 180)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * speed);
            }
            else if (transform.eulerAngles.x > 1 && transform.eulerAngles.x < 180)
            {
                transform.Rotate(Vector3.left * Time.deltaTime * speed);
            }
        }
        if (Input.GetAxis("Horizontal") == -0.5)
        {
            if (transform.eulerAngles.z < 359 && transform.eulerAngles.z > 180)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);
            }
            else if (transform.eulerAngles.z > 1 && transform.eulerAngles.z < 180)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * speed);
            }
        }
    }
}
