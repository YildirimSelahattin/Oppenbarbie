using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    //[SerializeField] private GameObject _explosionSound;
    private Vector3 dir;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            UIManager.Instance.restartButon.SetActive(true);
            Vector3 furthestContactPoint = transform.position;
            float furthestDistance = 0;
            foreach (ContactPoint contact in collision.contacts)
            {
                float currentDistance = Vector3.Distance(transform.position, contact.point);
                if (currentDistance > furthestDistance)
                {
                    furthestDistance = currentDistance;
                    furthestContactPoint = contact.point;
                }
            }
            collision.gameObject.GetComponent<MarchingCubes>().Destruction(furthestContactPoint, _radiusExplosion);
            //Instantiate(_explosionSound, transform.position, Quaternion.identity);
            Destroy(MissileController.Instance.target);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndCam"))
        {
            GameManager.Instance.ChangeCamera(GameManager.Instance.endCam, 50);
        }
    }

    public void SetDir(Vector3 _dir)
    {
        dir = _dir;
    }
}
