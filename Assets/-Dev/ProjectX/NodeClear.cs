using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClear : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Node"))
        {
            other.tag = "FlyingNode";
        }
    }
}
