using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class DragDropSystem : MonoBehaviour
{
    public static DragDropSystem Instance;
    private Touch touch;
    public GameObject temp;
    public LayerMask layerMask;
    public LayerMask draggingLayerMask;
    public GameObject touchedObject;
    public GameObject touchedRocketPart;
    Vector3 doubleTouchedObjBaseRot;
    Vector3 touchedObjBasePos;
    Vector3 touchedObjObjBaseRot;
    Vector3 previousPosition;
    public bool isplaceable = true;
    private BoxCollider[] boxColliders;
    public Color touchedObjBaseColor;
    public GameObject grid;
    public GameObject lastClosedObject;
    public GameObject lastInstObject;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, draggingLayerMask))
                {
                    touchedObject = hit.collider.gameObject;

                    // Clicking on an already attached part on missile
                    if (touchedObject.GetComponent<AttachedMissileProperties>() != null && touchedObject.GetComponent<AttachedMissileProperties>().partLevel > 0)
                    {
                        lastClosedObject = touchedObject;
                        lastClosedObject.transform.parent.GetChild(0).gameObject.SetActive(true);
                        lastClosedObject.SetActive(false);
                        lastInstObject = InstantiatePart(lastClosedObject);
                        if (lastClosedObject.tag == "Nozzle")
                        {
                            TrajectoryController.Instance.CalculateNozzlesBalance(touchedObject.GetComponent<AttachedMissileProperties>().nozzlePosition.ToString(), -lastInstObject.GetComponent<MissilePartsController>().levelIndex);
                        }

                        lastInstObject.transform.localScale = new Vector3(400 * 0.07f, 400 * 0.07f, 400 * 0.07f);
                        lastInstObject.transform.position = hit.point;
                        touchedObject = lastInstObject;

                    }

                    // Clicking on a non attached part
                    else
                    {
                        touchedObjBasePos = hit.transform.localPosition;
                        touchedObjObjBaseRot = hit.transform.rotation.eulerAngles;
                        touchedObject.layer = LayerMask.NameToLayer("DraggingBegan");
                        touchedObjBaseColor = touchedObject.GetComponent<MeshRenderer>().material.color;
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (touchedObject != null)
                {
                    if (touchedObject.GetComponent<AttachedMissileProperties>() != null)
                    {
                        touchedObject = null;

                    }

                    else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        Vector3 temp = touchedObject.transform.position;
                        temp = hit.point;
                        touchedObject.transform.position = temp;

                        if (touchedObject.name.Equals("DragMissile"))
                        {
                            Debug.LogError("asdasdasds");
                        }
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touchedObject != null)
                {
                    // Replace it to grid back
                    if (touchedObject.transform.parent.CompareTag("GridCell"))
                    {
                        touchedObject.GetComponent<MissilePartsController>().TouchEnded();
                        touchedObject = null;
                    }

                    else
                    {
                        if (touchedObject.GetComponent<MissilePartsController>().gridToSnap != null)
                        {
                            touchedObject.GetComponent<MissilePartsController>().TouchEnded();
                            touchedObject = null;
                        }
                        // Replace back the attached part
                        else
                        {
                            Destroy(lastInstObject);
                            if (touchedObject.CompareTag("Nozzle"))
                            {
                                TrajectoryController.Instance.CalculateNozzlesBalance(lastClosedObject.GetComponent<AttachedMissileProperties>().nozzlePosition.ToString(), lastInstObject.GetComponent<MissilePartsController>().levelIndex);
                            }
                            lastClosedObject.SetActive(true);
                            lastClosedObject.transform.parent.GetChild(0).gameObject.SetActive(false);
                            touchedObject = null;
                        }

                    }
                }
            }
        }
    }

    public GameObject InstantiatePart(GameObject partToInst)
    {
        string lastTag = partToInst.tag;
        int partLevel = partToInst.GetComponent<AttachedMissileProperties>().partLevel;
        if (partLevel > 0)
        {
            switch (lastTag)
            {
                case "Head":
                    Debug.Log("Head" + partLevel);
                return Instantiate(GridManager.Instance.Heads[partLevel - 1], grid.transform);

                case "WingU":
                    Debug.Log("WingU");
                    return Instantiate(GridManager.Instance.WingUs[partLevel - 1], grid.transform);


                case "Nozzle":
                    Debug.Log("WingsU");
                    return Instantiate(GridManager.Instance.Nozzles[partLevel - 1], grid.transform);


                case "WingD":
                    Debug.Log("WingD");
                    return Instantiate(GridManager.Instance.WingDs[partLevel - 1], grid.transform);

                default:
                    return null;

            }
        }

        else
        {
            return null;
        }
    }
}