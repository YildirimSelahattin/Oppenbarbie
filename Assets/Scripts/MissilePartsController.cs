using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissilePartsController : MonoBehaviour
{
    public enum PartType { head, wingD, Nozzle, wingU };
    public PartType partType = new PartType();
    public int levelIndex;
    public GameObject gridToSnap;
    public GameObject objectToMerge;
    public GameObject deleteItem;
    public GameObject attachedToMissile;
    public bool isRotate;
    private Color prevColor;

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
            Debug.Log("Hey");
            if (other.gameObject.GetComponent<MissilePartsController>() == null)
            {
                Debug.Log("Hey1");

                attachedToMissile = other.gameObject;
                prevColor = attachedToMissile.GetComponent<MeshRenderer>().material.color;
                attachedToMissile.GetComponent<MeshRenderer>().material.color = Color.magenta;
                
            }
            else if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex && levelIndex != 5)
            {
                Debug.Log("Hey2");

                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
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
                attachedToMissile.GetComponent<MeshRenderer>().material.color = prevColor;
                attachedToMissile = null;
            }
            else if (other.gameObject.GetComponent<MissilePartsController>().levelIndex == levelIndex)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = DragDropSystem.Instance.touchedObjBaseColor;
                objectToMerge = null;
            }
            else
            {
                attachedToMissile.GetComponent<MeshRenderer>().material.DOKill();
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
        // Object Merge
        if (objectToMerge != null)
        {
            GameObject tempParent = objectToMerge.transform.parent.gameObject;

            Destroy(objectToMerge);
            if (gameObject.CompareTag("Nozzle"))
            {
                Instantiate(GridManager.Instance.Nozzles[levelIndex], tempParent.transform);


                if (GetComponentInParent<MissileProperties>() != null)
                {
                    TrajectoryController.Instance.CalculateNozzlesBalance(GetComponentInParent<MissileProperties>().nozzlePosition.ToString(), -levelIndex);
                }

                if (objectToMerge.GetComponentInParent<MissileProperties>() != null)
                {
                    TrajectoryController.Instance.CalculateNozzlesBalance(objectToMerge.GetComponentInParent<MissileProperties>().nozzlePosition.ToString(), 1);
                }
            }

            else if (gameObject.CompareTag("Head"))
            {
                Debug.Log("Head");
                Instantiate(GridManager.Instance.Heads[levelIndex], tempParent.transform);
            }
            else if (gameObject.CompareTag("WingD"))
            {
                Debug.Log("WingD");

                Instantiate(GridManager.Instance.WingDs[levelIndex], tempParent.transform);
            }
            else if (gameObject.CompareTag("WingU"))
            {
                Debug.Log("WingU");

                Instantiate(GridManager.Instance.WingUs[levelIndex], tempParent.transform);
            }
            Destroy(gameObject);
        }

        // Attachment
        else if (attachedToMissile != null)
        {
            // Attachment Without Merge
            if (attachedToMissile.GetComponent<MissileProperties>().partLevel < levelIndex)
            {
                Debug.Log("upgrade");

                UpgradeWithoutMerge();
            }

            // Attachment With Merge
            else if (attachedToMissile.GetComponent<MissileProperties>().partLevel == levelIndex)
            {
                Debug.Log("equal");
                UpgradeWithMerge();
            }

            else
            {
                transform.localPosition = new Vector3(0, 2.5f, 0);
                gridToSnap = null;
            }    

        }
        else
        {
            if (gridToSnap != null)
            {
                if (transform.parent.GetComponent<MissileProperties>() != null)
                {
                    TrajectoryController.Instance.CalculateNozzlesBalance(GetComponentInParent<MissileProperties>().nozzlePosition.ToString(), -levelIndex);
                }

                transform.parent = gridToSnap.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);

            }
            else if (attachedToMissile != null && attachedToMissile.transform.childCount == 0)
            {
                transform.parent = gridToSnap.transform;
                transform.localPosition = new Vector3(0, 2.5f, 0);
            }
            else if (deleteItem != null)
            {
                if (transform.parent.GetComponent<MissileProperties>() != null)
                {
                    TrajectoryController.Instance.CalculateNozzlesBalance(GetComponentInParent<MissileProperties>().nozzlePosition.ToString(), -levelIndex);
                }
                Destroy(deleteItem);
            }
            else
            {
                transform.localPosition = new Vector3(0, 2.5f, 0);
                gridToSnap = null;
            }
        }
    }


    // Attachment Without Merge
    void UpgradeWithoutMerge()
    {

        // Nozzle Attachment Without Merge
        if (gameObject.CompareTag("Nozzle"))
        {

            // Calculates the Trajectory
            TrajectoryController.Instance.CalculateNozzlesBalance(attachedToMissile.GetComponent<MissileProperties>().nozzlePosition.ToString(), levelIndex);
            TrajectoryController.Instance.CalculateNozzlesBalance(attachedToMissile.GetComponent<MissileProperties>().nozzlePosition.ToString(), attachedToMissile.GetComponent<MissileProperties>().partLevel);

            // Makes the Visual Change
            AttachPart(levelIndex);
        }

        // Head or Wing Attachment Without Merge
        else if (gameObject.CompareTag("Head") || gameObject.CompareTag("WingD") || gameObject.CompareTag("WingU"))
        {
            AttachPart(levelIndex);
        }
    }

    void UpgradeWithMerge()
    {
        // Nozzle Attachment Without Merge
        if (gameObject.CompareTag("Nozzle"))
        {

            // Calculates the Trajectory
            TrajectoryController.Instance.CalculateNozzlesBalance(attachedToMissile.GetComponent<MissileProperties>().nozzlePosition.ToString(), levelIndex);
            TrajectoryController.Instance.CalculateNozzlesBalance(attachedToMissile.GetComponent<MissileProperties>().nozzlePosition.ToString(), attachedToMissile.GetComponent<MissileProperties>().partLevel + 1);

            // Makes the Visual Change
            AttachPart(levelIndex + 1);
        }

        // Head or Wing Attachment With Merge
        else if (gameObject.CompareTag("Head") || gameObject.CompareTag("WingD") || gameObject.CompareTag("WingU"))
        {
            AttachPart(levelIndex + 1);
        }
    }

    void AttachPart(int levelIndex)
    {
        attachedToMissile.transform.parent.GetChild(levelIndex).gameObject.SetActive(true);
        attachedToMissile.SetActive(false);
        Destroy(gameObject);
    }

}
