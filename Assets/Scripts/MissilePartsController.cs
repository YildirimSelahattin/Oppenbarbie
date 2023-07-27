using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePartsController : MonoBehaviour
{
    public enum PartType { head, wing, Nozzle };
    public PartType partType = new PartType();
    public int levelIndex = 1;
    public GameObject gridToSnap;
    public GameObject objectToMerge;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GridCell"))
        {
            if (other.gameObject.transform.childCount == 0)
            {
                gridToSnap = other.gameObject;
            }
        }

        if (other.CompareTag(gameObject.tag))
        {
            if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex)
            {
                objectToMerge = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GridCell"))
        {
            if (other.gameObject == gridToSnap)
            {
                gridToSnap = null;
            }
        }

        if (other.CompareTag(gameObject.tag))
        {
            if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex)
            {
                objectToMerge = null;
            }
        }
    }

    public void TouchEnded()
    {
        if (objectToMerge != null)
        {
            GameObject tempParent = objectToMerge.transform.parent.gameObject;
            Destroy(objectToMerge);
            Instantiate(GridManager.Instance.part[3], tempParent.transform);
            Destroy(gameObject);
        }
        else
        {
            if (gridToSnap != null)
            {
                transform.parent = gridToSnap.transform;
                transform.localPosition = new Vector3(0, 1.2f, 0);
            }
            else
            {
                transform.localPosition = new Vector3(0, 1.2f, 0);
                gridToSnap = null;
            }
        }
    }
}
