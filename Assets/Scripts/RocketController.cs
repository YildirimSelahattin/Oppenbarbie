using UnityEngine;

public class RocketController : MonoBehaviour
{
    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);
            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, screenTouch.deltaPosition.x, 0f);
            }

        }

        transform.Translate(Vector3.back * (1 * -1 * Time.deltaTime));
    }
}