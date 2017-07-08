using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour {
    public GameObject[] bulletPrefabs;
    public GameObject bulletManager;
    public LayerMask enemyLayer;
    float range = 100f;
    float damage = 10f;
    float fireRate = 0.5f;
    float nextFire = 0.0f;
    Vector3 targetLimited;
    bool isDestroy = false;
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        if(Input.GetButton("Fire2"))
        {
            print("Fire2");
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        SpawnBullet(targetLimited);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, enemyLayer.value))
        {
            Debug.Log(hit.transform.name);
            targetLimited = transform.position + Vector3.forward * 100;
            
            Enemies enemies = hit.transform.GetComponent<Enemies>();
            if(enemies != null)
            {
                isDestroy = true;
                enemies.TakeDamage(damage);
            }
        }
    }

    void SpawnBullet(Vector3 targetLimited)
    {
        GameObject gameObj = Instantiate(bulletPrefabs[0]) as GameObject;
        gameObj.transform.SetParent(transform);
        gameObj.transform.position = transform.position;
        gameObj.transform.rotation = transform.rotation;
        gameObj.transform.SetParent(bulletManager.transform);
    }
    void DestroyBullet()
    {

    }
}
