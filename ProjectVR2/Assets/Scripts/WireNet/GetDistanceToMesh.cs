using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistanceToMesh : MonoBehaviour
{
    public Transform footPos;
    private Mesh mesh;
    private Vector3[] originalVertices;
    int targetVertice;
    [System.NonSerialized] public float targetHight;
    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
    }
    void Update()
    {
        float dis = 100f;
        for (int i = 0; i < originalVertices.Length; i++)
        {
            if(dis>Vector3.Distance(footPos.position, originalVertices[i]+transform.position)){
                targetVertice = i;
            }
        }
        targetHight = footPos.position.y - (originalVertices[targetVertice]+transform.position).y;
    }
}
