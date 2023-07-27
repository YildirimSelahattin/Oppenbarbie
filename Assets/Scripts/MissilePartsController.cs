using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePartsController : MonoBehaviour
{
    public enum PartType { head, wing, Nozzle };
    public PartType partType = new PartType();
    public int levelIndex;
    public GameObject gridToSnap;
    public GameObject objectToMerge;
    public GameObject deleteItem;

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

        if (other.CompareTag("DeleteCell"))
        {
            deleteItem = gameObject;
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
            if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex && levelIndex != 5)
            {
                objectToMerge = null;
            }
        }

        if (other.CompareTag("DeleteCell"))
        {
            deleteItem = null;
        }
    }

    public void TouchEnded()
    {
        if (objectToMerge != null)
        {
            GameObject tempParent = objectToMerge.transform.parent.gameObject;
            Destroy(objectToMerge);
            if (gameObject.CompareTag("Head"))
            {
                Instantiate(GridManager.Instance.Heads[levelIndex], tempParent.transform);
            }
            if (gameObject.CompareTag("Wing"))
            {
                Instantiate(GridManager.Instance.Wings[levelIndex], tempParent.transform);
            }
            if (gameObject.CompareTag("Nozzle"))
            {
                Instantiate(GridManager.Instance.Nozzles[levelIndex], tempParent.transform);
            }
            Destroy(gameObject);
        }
        else
        {
            if (gridToSnap != null)
            {
                transform.parent = gridToSnap.transform;
                transform.localPosition = new Vector3(0, 1.2f, 0);
            }
            else if(deleteItem != null)
            {
                Destroy(deleteItem);
            }
            else
            {
                transform.localPosition = new Vector3(0, 1.2f, 0);
                gridToSnap = null;
            }
        }
    }
}
