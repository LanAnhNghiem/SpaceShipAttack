using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunching : MonoBehaviour {
    public GameObject[] rocketPrefabs;
    public GameObject rocketManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2"))
        {
            Spawn();
        }
	}

    void Spawn()
    {
        GameObject gameObj = Instantiate(rocketPrefabs[0]) as GameObject;
        gameObj.transform.SetParent(transform);
        gameObj.transform.position = transform.position;
        gameObj.transform.rotation = transform.rotation;
        gameObj.transform.SetParent(rocketManager.transform);
    }
}
