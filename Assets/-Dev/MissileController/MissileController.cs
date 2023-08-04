using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public static MissileController Instance;
    [Range(0, 5000)]
    public float speed = 0;
    [SerializeField]
    public GameObject target = null;
    [SerializeField]
    private float _maxAngularVelocity = 20;
    private Rigidbody _rb;
    Vector3 aimedDirection;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.maxAngularVelocity = _maxAngularVelocity;
        target = Instantiate(GameManager.Instance.targetPrefab);
    }

    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
        var targetDirection = (transform.position - target.transform.position).normalized;
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
