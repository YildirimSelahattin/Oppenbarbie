using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5000)]
    private float _thrust = 10;
    [SerializeField]
    private GameObject _target = null;
    [SerializeField]
    private float _maxAngularVelocity = 20;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.maxAngularVelocity = _maxAngularVelocity;
    }

    void FixedUpdate()
    {
        var targetDirection = transform.position - _target.transform.position;
        Vector3 rotationDirection = Vector3.RotateTowards(transform.forward, targetDirection, 360, 0.00f);
        Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);

        _rb.AddRelativeForce((-Vector3.forward) * _thrust * Time.fixedDeltaTime);

        transform.rotation = targetRotation;
    }
}
