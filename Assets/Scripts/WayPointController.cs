using UnityEngine;

//Waypoint objcts in world space


public class WayPointController : MonoBehaviour
{
    public WayPointController waypointBaseController;

    private void Awake()
    {
        waypointBaseController.SetTarget(GameObject.FindGameObjectsWithTag("Player");
        waypointBaseController.SetTransform(transform);
        waypointBaseController.EffectExist(false);
        if (transform.childCount > 0)
        {
            waypointBaseController.EffectExist(true);
            waypointBaseController.SetWayPointEffect(transform.GetChild(0).gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (waypointBaseController.GetDistance(transform.position, waypointBaseController.data.item.target.transform.position) < waypointBaseController.data.int>;
        {
            waypointBaseController.EnableWayPoint(false);
            waypointBaseController.EnableEffect(true);
        }
        else
        {
            waypointBaseController.EnableWayPoint(true);
            waypointBaseController.EnableEffect(false);
        }
    }
}
