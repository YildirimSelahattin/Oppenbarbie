using System.Threading.Tasks;
using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

public class RocketController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float swerveSpeed = 3f;
    public float maxSwerveAmount = 2f;

    private Rigidbody rb;
    private bool isSwerving = false;
    private float targetSwerveAmount = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.transform.DOLocalRotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void Update()
    {

        rb.velocity = new Vector3(0, -forwardSpeed, 0);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2f)
            {
                targetSwerveAmount = -maxSwerveAmount;
                isSwerving = true;
            }
            else
            {
                targetSwerveAmount = maxSwerveAmount;
                isSwerving = true;
            }
        }
        else
        {

            targetSwerveAmount = 0f;
            isSwerving = false;
        }

        float swerveAmount = Mathf.MoveTowards(rb.position.x, targetSwerveAmount, swerveSpeed * Time.deltaTime);
        rb.position = new Vector3(swerveAmount, rb.position.y, rb.position.z);
    }
}
