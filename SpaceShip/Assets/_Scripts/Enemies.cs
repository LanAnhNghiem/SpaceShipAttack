using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public float health = 50f;
    public int index;
    public WaypointManager wpMan;
    public int wpNextIndex;
    public GameObject player;
    float timer = 0.0f;
    float movementSpeed = 1f;
    float rotationSpeed = 1f;
    float delayTime;
    float deltaTime;
    float speed = 0.5f;
    int numsOfWaypoint;
    private void Start()
    {
        numsOfWaypoint = wpMan.activeWaypoint.Count;
        deltaTime = 0.5f;
        if (index < numsOfWaypoint / 4)
            delayTime = deltaTime * index / speed;
        else
            delayTime = deltaTime * (numsOfWaypoint / 2 - index - 1) / speed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if(Time.time > delayTime)
        {
            if (index < numsOfWaypoint / 4) 
                Moving(numsOfWaypoint / 2 - index * 2);
            else
                Moving(numsOfWaypoint - (numsOfWaypoint / 2 - index - 1) * 2);
        }
        Vector3 relativePos = player.transform.position - transform.position;
         Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
    }
    void Moving(float waypointIndex)
    {
        if (wpNextIndex < waypointIndex)
        {
            Vector3 targetPos = wpMan.activeWaypoint[wpNextIndex].transform.position;
            if (Vector3.Distance(transform.position, targetPos) <
                movementSpeed * Time.deltaTime)
            {
                wpNextIndex ++;
                if (wpNextIndex >= waypointIndex)
                    return;
            }
            // Go to current target
            targetPos = wpMan.activeWaypoint[wpNextIndex].transform.position;
            float targetSpeed = 10f;//wpMan.activeWaypoint[wpNextIndex].speed;
            transform.position = Vector3.MoveTowards(
            transform.position, targetPos, movementSpeed * targetSpeed * Time.deltaTime);

            Quaternion desiredRot = Quaternion.LookRotation(
                targetPos - wpMan.activeWaypoint[wpNextIndex - 1].transform.position,
                Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                desiredRot, rotationSpeed * Time.deltaTime);
        }
    }
    
}
