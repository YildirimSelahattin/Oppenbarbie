using System.Threading.Tasks;
using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool MoveByTouch, StartTheGame;
    private Vector3 _mouseStartPos, PlayerStartPos;
    public float RoadSpeed;
    [SerializeField] private float SwipeSpeed, Distance;
    [SerializeField] private GameObject Road;
    private Camera mainCam;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            MoveByTouch = false;
        }

        if (MoveByTouch && StartTheGame)
        {
            var plane = new Plane(Vector3.up, 0f);

            float distance;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 mousePos = ray.GetPoint(distance);
                Vector3 desirePso = mousePos - _mouseStartPos;
                Vector3 move = PlayerStartPos + desirePso;

                move.x = Mathf.Clamp(move.x, -2.2f, 2.2f);

                move.z = -7f;

                var player = transform.position;

                player = new Vector3(Mathf.Lerp(player.x, move.x, Time.deltaTime * (SwipeSpeed + 10f)), player.y, player.z);

                transform.position = player;
            }
        }
    }
}