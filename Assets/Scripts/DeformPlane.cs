using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    [SerializeField] float deformRadius;
    [SerializeField] float deformPower;

    MeshFilter m_meshFilter;
    MeshCollider m_meshCollider;

    Mesh playMesh;
    Vector3[] m_vertices;

    // Start is called before the first frame update
    void Start()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_meshCollider = GetComponent<MeshCollider>();

        playMesh = m_meshFilter.mesh;
        m_vertices = playMesh.vertices;
    }

    public void DeformPlayMesh(Vector3 deformPos)
    {
        deformPos = transform.InverseTransformPoint(deformPos);

        for(int i = 0; i < m_vertices.Length; i++)
        {
            float dist = (m_vertices[i] - deformPos).sqrMagnitude;
            if(dist < deformRadius)
            {
                m_vertices[i] -= Vector3.back * deformPower;
            }
        }
        playMesh.vertices = m_vertices;
        m_meshCollider.sharedMesh = playMesh;
    }
}