using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAssigner : MonoBehaviour
{
    public List<GameObject> objectList;
    public Transform parentTransform;

    void Start()
    {
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            GameObject child = parentTransform.GetChild(i).gameObject;
            MeshFilter meshFilter = child.GetComponent<MeshFilter>();
            MeshCollider meshColl = child.GetComponent<MeshCollider>();

            Mesh objMesh = objectList[i].transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh;

            meshFilter.sharedMesh = objMesh;
            meshColl.sharedMesh = objMesh;
        }

        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        //UnityEditor.PrefabUtility.SaveAsPrefabAsset(gameObject, "Assets/Prefabs/MyPrefab.prefab");
    }
}
