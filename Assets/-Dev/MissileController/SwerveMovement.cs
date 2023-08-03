using System;
using UnityEngine;
using DG.Tweening;

public class SwerveMovement : MonoBehaviour
{
    public static SwerveMovement Instance;
    public float speed = 0;
    public float startPosX;
    public bool isStartGame;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GoStartPos()
    {
        startPosX = TrajectoryController.Instance.nozzleBalance * -2.5f;
        transform.DOMoveX(startPosX, 1.5f).OnComplete(() => isStartGame = true);
    }

    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if (Input.touchCount > 0 && isStartGame == true)
        {
            Touch touch = Input.GetTouch(0);
            float horizontalInput = touch.position.x - Screen.width / 2f;
            float movement = horizontalInput / (Screen.width / 2f);
            transform.Translate(Vector3.right * -movement * speed * Time.deltaTime);
        }
    }


}