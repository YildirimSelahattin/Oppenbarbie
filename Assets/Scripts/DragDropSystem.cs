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
    Vector3 doubleTouchedObjBaseRot;
    Vector3 touchedObjBasePos;
    Vector3 touchedObjObjBaseRot;
    Vector3 previousPosition;
    public bool isplaceable = true;
    private BoxCollider[] boxColliders;

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
                    touchedObject = hit.transform.gameObject;
                    touchedObjBasePos = hit.transform.localPosition;
                    touchedObjObjBaseRot = hit.transform.rotation.eulerAngles;
                    touchedObject.layer = LayerMask.NameToLayer("DraggingBegan");

                    //touchedObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (touchedObject != null)
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        Vector3 temp = touchedObject.transform.position;
                        temp = hit.point;
                        touchedObject.transform.position = temp;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touchedObject != null)
                {
                    touchedObject.GetComponent<MissilePartsController>().TouchEnded();
                    touchedObject = null;
                }
            }
        }
    }
}