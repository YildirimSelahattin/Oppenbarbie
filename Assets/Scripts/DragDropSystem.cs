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

                    if (touchedObject.GetComponent<AttachedMissileProperties>())
                    {
                        lastClosedObject = touchedObject;
                        touchedObject.SetActive(false);
                        lastClosedObject.transform.parent.GetChild(0).gameObject.SetActive(true);
                        lastInstObject = Instantiate(GridManager.Instance.Heads[1], grid.transform);
                        lastInstObject.transform.localScale = new Vector3(400 * 0.07f, 400 * 0.07f, 400 * 0.07f);
                        lastInstObject.transform.position = hit.point;
                        touchedObject = lastInstObject;

                    }

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
                    Debug.LogError("ksadhgfasgfd");

                    if (touchedObject.transform.parent.CompareTag("GridCell"))
                    {
                        touchedObject.GetComponent<MissilePartsController>().TouchEnded();
                        touchedObject = null;
                        Debug.LogError("sadasgfd");
                    }

                    else
                    {
                        if (touchedObject.GetComponent<MissilePartsController>().gridToSnap != null)
                        {
                            touchedObject.GetComponent<MissilePartsController>().TouchEnded();
                            touchedObject = null;


                        }
                        else
                        {
                            Destroy(lastInstObject);
                            lastClosedObject.SetActive(true);
                            touchedObject = null;
                        }
                        
                    }
                }
            }
        }
    }
}