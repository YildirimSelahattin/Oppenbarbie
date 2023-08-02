using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5000)]
    private float speed = 2;
    [SerializeField]
    private GameObject _target = null;
    [SerializeField]
    private float _maxAngularVelocity = 20;
    private Rigidbody _rb;
    Vector3 aimedDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.maxAngularVelocity = _maxAngularVelocity;
    }

    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
        var targetDirection = (transform.position - _target.transform.position).normalized;
        aimedDirection = targetDirection;

        if (aimedDirection.x - transform.up.x < 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - 0.05f);
        }
        if (aimedDirection.x - transform.up.x > 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 0.05f);
        }
    }
}
