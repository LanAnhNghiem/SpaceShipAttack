using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotate : MonoBehaviour {
    float speed = 1000f;
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up * Time.deltaTime * speed);
	}
}
