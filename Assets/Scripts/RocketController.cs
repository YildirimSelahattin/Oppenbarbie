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
    [SerializeField] private float SwipeSpeed;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        MoveByTouch = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveByTouch = true;
            StartTheGame = true;

            Plane newPlan = new Plane(Vector3.forward, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            MoveByTouch = false;
            transform.DOKill();
        }

        if (MoveByTouch && StartTheGame)
        {
            var plane = new Plane(Vector3.forward, 0f);

            float distance;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 mousePos = ray.GetPoint(distance);
                Vector3 desirePos = mousePos - _mouseStartPos;
                Vector3 move = transform.position + desirePos;

                move.x = Mathf.Clamp(move.x, -2.2f, 2.2f);
                move.z = -7f;

                Quaternion targetRotation = Quaternion.LookRotation(move - transform.position, Vector3.up);

                float step = SwipeSpeed * Time.deltaTime;
                Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

                Vector3 newEulerAngles = newRotation.eulerAngles;
                newEulerAngles.x = 180;
                newEulerAngles.y = 0;
                newEulerAngles.z = Mathf.Clamp(newEulerAngles.z, -60, 60);

                newRotation = Quaternion.Euler(newEulerAngles);

                transform.rotation = newRotation;
            }
        }

        if (StartTheGame)
        {
            transform.Translate(Vector3.down * (RoadSpeed * -1 * Time.deltaTime));
        }
    }
}