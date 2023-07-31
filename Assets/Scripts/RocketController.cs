using System.Threading.Tasks;
using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

public class RocketController : MonoBehaviour
{
    [HideInInspector] public bool MoveByTouch, StartTheGame;
    private Vector3 _mouseStartPos, PlayerStartPos;
    public float RoadSpeed;
    Vector3 screenMyPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                screenMyPosition = Input.GetTouch(0).position / 2f;
            }
            
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 myPosition = gameObject.transform.position;
                Vector3 targetPosition = touch.position / 2f;
                Vector3 direction = (targetPosition - screenMyPosition).normalized;
                Vector3 tempDir = new Vector3(direction.x, -1f, 0);
                transform.LookAt(tempDir + transform.position);
            }
        }

        if (true)
        {
            transform.Translate(Vector3.back * (1 * -1 * Time.deltaTime));
        }
    }
}