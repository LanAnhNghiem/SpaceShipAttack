using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    public GameObject enemy;
    public Waypoint waypointPrefab;
    public float lineWidth = 0.2f;
    public List<Waypoint> activeWaypoint = new List<Waypoint>();
    float radius = 10f;
    int vertexCount = 20;
    LineRenderer lineRenderer;
    int numOfWaypoint = 20;
    EnemyManager enemyManager;
    float yAxis = -1.0f;
    
    // Use this for initialization
    void Start () {
        enemyManager = enemy.GetComponent<EnemyManager>();
        Draw(1);
        Draw(-1);
    }

    void Draw(int value)
    {
        float deltaTheta = (1.0f * Mathf.PI) / vertexCount;
        float theta = 0.0f;
        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertexCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Sin(theta) *value, yAxis, radius * Mathf.Cos(theta) *value);
            Spawn(pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
        enemyManager.enabled = true;
    }

    void Spawn(Vector3 pos)
    {
        Waypoint gameObject = Instantiate(waypointPrefab);
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = pos;
        activeWaypoint.Add(gameObject);
    }
}
