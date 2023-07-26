using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformBall : MonoBehaviour
{
    public DeformPlane deformPlane;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the deformPlane
        if (collision.gameObject == deformPlane.gameObject)
        {
            // Get the collision point and deform the playMesh at that point
            Vector3 collisionPoint = collision.contacts[0].point;
            deformPlane.DeformPlayMesh(collisionPoint);

            StartCoroutine(Delay(gameObject));
        }
    }

    IEnumerator Delay(GameObject item)
    {
        item.GetComponent<Collider>().enabled = false;
        item.transform.GetChild(0).GetComponent<Collider>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Destroy(item);
    }
}