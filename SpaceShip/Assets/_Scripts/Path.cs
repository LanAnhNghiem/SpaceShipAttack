using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public int vertexCount = 40; //nums of vertex, càng nhiều càng smooth
    public float lineWidth = 0.2f;
    public float radius;
    //public bool circleFillscreen;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;
        for(int i = 0;i<vertexCount +1;i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), 0.0f, radius * Mathf.Sin(theta));
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }
#endif
}
