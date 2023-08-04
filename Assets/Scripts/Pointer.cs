using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public static Pointer Instance;
    public Transform target;
    public MeshRenderer img;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        img = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
    }
}