using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseNet : MonoBehaviour
{
    [SerializeField] private float heightScale = 5.0f;
    [SerializeField] private float timeScale = 0.5f;
    [SerializeField] private float noiseScale = 0.3f;
    [SerializeField] private Vector3 noiseOffset = Vector3.one;


    private Mesh mesh;
    private Vector3[] originalVertices;


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
    }
    private void Update()
    {
        float time = Time.time * timeScale;
        Vector3[] vertices = new Vector3[originalVertices.Length];
        float dis = 100f;
        for (int i = 0; i < originalVertices.Length; i++)
        {
            Vector3 v = originalVertices[i];
            float n = Noise.PerlinNoise(v.x * noiseScale + noiseOffset.x, v.z * noiseScale + noiseOffset.y, time + noiseOffset.z) * heightScale;
            vertices[i] = originalVertices[i] + new Vector3(0, n, 0);

            
        }
        mesh.vertices = vertices;
        //mesh.RecalculateNormals();

    }
}
