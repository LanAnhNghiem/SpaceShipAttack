using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    public float smoothTime;
    Vector3 velocity;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(0, 3, -6);
        transform.SetParent(null);
	}

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.TransformPoint(offset), ref velocity, smoothTime);// bien toa do offset tu local thanh world
        transform.LookAt(player.position);

    }

}
