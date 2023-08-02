using System;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    public float speed = 5f; // Hareket hızı

    void Update()
    {
        transform.Translate(Vector3.down * (2 * Time.deltaTime));

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float horizontalInput = touch.position.x - Screen.width / 2f;
            float movement = horizontalInput / (Screen.width / 2f);
            transform.Translate(Vector3.right * -movement * speed * Time.deltaTime);
        }
    }
}