using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionWaypoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public TextMeshProUGUI meter;

    [Header("Control Points")]
    public Transform[] controlPoints;
    private Vector2 gizmosPosition;


    private void Update()
    {
        
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if (Vector3.Dot((transform.position - target.position), transform.forward) < 0)
        {
            if (pos.x > Screen.width / 2) // define the sides of arrows
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
        img.transform.up =  target.transform.position - transform.position;
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
        
    }

    private void OnDrawGizmos()
    {
        for (float t= 0; t <=1 ; t+= 0.05f) 
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3*Mathf.Pow(1-t,2) * t * controlPoints[1].position + 
                3* (1-t) * Mathf.Pow(t,2) * controlPoints[2].position + 
                Mathf.Pow(t,3)  * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
            new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));
        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
            new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));

    }
}
