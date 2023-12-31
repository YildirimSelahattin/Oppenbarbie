using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Node"))
        {
            UIManager.Instance.restartButon.SetActive(true);
            StartCoroutine(Explosion());
            Destroy(MissileController.Instance.target, 1f);
            Destroy(gameObject, 1f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndCam"))
        {
            GameManager.Instance.ChangeCamera(GameManager.Instance.endCam, 50);
            StartCoroutine(DelayCam());
        }
        if (other.CompareTag("Finish"))
        {
            UIManager.Instance.restartButon.SetActive(true);
            Destroy(MissileController.Instance.target, .5f);
            Destroy(gameObject, .5f);
        }
    }

    public IEnumerator DelayCam()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.endCam.LookAt = null;
        GameManager.Instance.endCam.Follow = null;
    }

    public IEnumerator Explosion()
    {
        GameManager.Instance.explosionEffect.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        GameManager.Instance.explosionSphere.SetActive(true);
    }
}