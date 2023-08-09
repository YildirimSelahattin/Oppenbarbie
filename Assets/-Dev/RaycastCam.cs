using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{
Ray m_ray;
    RaycastHit m_rayHit;

    Camera m_cam;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = transform.GetComponent<Camera>();    
    }

    private void FixedUpdate() 
    {
        if(Input.GetMouseButton(0))
        {
            deformPlayPlane();
        }    
    }

    void deformPlayPlane()
    {
        m_ray = m_cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(m_ray, out m_rayHit))
        {
            if(m_rayHit.transform.tag == "PlayMesh")
            {
                DeformPlane sPlaneDeformer = m_rayHit.transform.GetComponent<DeformPlane>();
                sPlaneDeformer.DeformPlayMesh(m_rayHit.point);
            }
        }
    }
}