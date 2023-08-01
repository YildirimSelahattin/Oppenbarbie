using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * (2 * -1 * Time.deltaTime));
    }
}
