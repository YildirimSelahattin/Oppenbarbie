using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClear : MonoBehaviour
{
    public Material[] flyingNodeMat;
    public int nodes;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Node"))
        {
            other.tag = "FlyingNode";
            other.GetComponent<MeshRenderer>().material = flyingNodeMat[GameDataManager.Instance.currentLevel - 1];
            nodes++;

            if(nodes == 310)
            {
                LevelManager.Instance.NextLevel();
            }
        }
    }
}
