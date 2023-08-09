using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class BombDeformManager : MonoBehaviour
{
    public enum BombType { Basic, Drill };
    public BombType _bombType = new BombType();
    public DeformPlane deformPlane;
    public GameObject blastEffect;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the deformPlane
        if (collision.gameObject == deformPlane.gameObject)
        {
            // Get the collision point and deform the playMesh at that point
            Vector3 collisionPoint = collision.contacts[0].point;
            deformPlane.DeformPlayMesh(collisionPoint);

            if (_bombType == BombType.Basic)
            {
                StartCoroutine(BasicBomb(gameObject));
            }
            if (_bombType == BombType.Drill)
            {
                StartCoroutine(DrilBomb(gameObject));
            }
        }
    }

    IEnumerator BasicBomb(GameObject item)
    {
        //GameManager.Instance.ShakeCamera(1);
        blastEffect.SetActive(true);
        yield return new WaitForSeconds(.5f);
        //GameManager.Instance.ShakeCamera(0);
        Destroy(item);
    }

    IEnumerator DrilBomb(GameObject item)
    {
        //GameManager.Instance.ShakeCamera(1);
        yield return new WaitForSeconds(1f);
        blastEffect.SetActive(true);   
        RotateDrill.Instance.RotateInPlanet(item);
    }
}