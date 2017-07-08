using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    void Update()
    {
       // print("Horizontal: " + Input.GetAxisRaw("Vertical"));
        if (Input.GetAxis("Horizontal") != -0.5 || Input.GetAxis("Vertical") != -0.5)
        {
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            float translation = Input.GetAxis("Vertical") * speed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            if(Input.GetAxis("Vertical") == 0.5)
                transform.Translate(0, 0, -translation);
            else if(Input.GetAxis("Vertical") > 0.5)
                transform.Translate(0, 0, translation);
            if (Input.GetAxis("Horizontal") == 0.5)
                transform.Rotate(0, rotation, 0);
            else if (Input.GetAxis("Horizontal") > 0.5)
                transform.Rotate(0, -rotation, 0);

        }

    }
}
