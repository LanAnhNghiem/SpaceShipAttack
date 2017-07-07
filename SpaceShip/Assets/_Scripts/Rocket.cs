using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Vector3 startPos;
    Vector3 endPos;
    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.forward * 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
        if (transform.position.z >= endPos.z)
        {
            //print("Destroy");
            Destroy(transform.gameObject);
        }
    }
}
