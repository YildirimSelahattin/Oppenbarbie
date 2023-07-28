using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissilePartsController : MonoBehaviour
{
    public enum PartType { head, wing, Nozzle };
    public PartType partType = new PartType();
    public int levelIndex;
    public GameObject gridToSnap;
    public GameObject objectToMerge;
    public GameObject deleteItem;
    public GameObject attachedToMissile;
    public bool isRotate;

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
            if (other.gameObject.GetComponent<MissilePartsController>() == null)
            {
                attachedToMissile = other.gameObject;
            }
            else if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex && levelIndex != 5)
            {
                objectToMerge = other.gameObject;
            }
        }

        if (other.CompareTag("DeleteCell"))
        {
            deleteItem = gameObject;
        }

        if (other.CompareTag("RotatePart"))
        {
            if (isRotate == false)
            {
                transform.DOLocalRotate(new Vector3(-30, 0, 0), .2f);
                isRotate = true;
            }
            else
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), .2f);
                isRotate = false;
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
            if (other.gameObject.GetComponent<MissilePartsController>() == null)
            {
                attachedToMissile = null;
            }
            else if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex)
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
        transform.DOLocalRotate(new Vector3(0, 0, 0), .1f);
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
        else if (attachedToMissile != null)
        {
            if (gameObject.CompareTag("Head"))
            {
                transform.parent = attachedToMissile.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);
            }
            if (gameObject.CompareTag("Wing"))
            {
                transform.parent = attachedToMissile.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);
            }
            if (gameObject.CompareTag("Nozzle"))
            {
                transform.parent = attachedToMissile.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);
            }
        }
        else
        {
            if (gridToSnap != null)
            {
                transform.parent = gridToSnap.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);
            }
            else if(attachedToMissile != null)
            {
                transform.parent = gridToSnap.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);
            }
            else if (deleteItem != null)
            {
                Destroy(deleteItem);
            }
            else
            {
                transform.localPosition = new Vector3(0, 2.5f, 0);
                gridToSnap = null;
            }
        }
    }
}
