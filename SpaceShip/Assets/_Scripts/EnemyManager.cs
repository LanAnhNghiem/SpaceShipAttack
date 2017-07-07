using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject[] enemyPrefab;
    public WaypointManager wpMan;
    public GameObject player;
    Enemies enemy;
    int index = 0;
    float timer = 0.0f;
    int numsOfEnemy = 10 ;
    // Use this for initialization
    void Start () {
        createEnemy(0);
        createEnemy(numsOfEnemy);
    }

    void createEnemy(int value)
    {
        for(int i=value; i< numsOfEnemy + value; i++)
        {
            Spawn(value);
            enemy = transform.GetChild(i).GetComponent<Enemies>();
            enemy.index = i;
            enemy.wpMan = wpMan;
            if(i < numsOfEnemy)
            {
                enemy.wpNextIndex = 1;
            }
            else
            {
                enemy.wpNextIndex = value * 2 + 1;
            }
            enemy.player = player;
        }
    }
    void Spawn(int value)
    {
        GameObject gameObj = Instantiate(enemyPrefab[0]) as GameObject;
        gameObj.transform.SetParent(transform);
        gameObj.transform.position = wpMan.activeWaypoint[value * 2].transform.position;
        index++;
    }
}
