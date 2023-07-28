using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To display all the waypoints ,mages and messages this happends live when bomb is falling
public class CameraWaypointController : CameraWaypointController
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (data.waypoints != null && data.waypoints.Counts > 0)
        {
            UpdateUI();
        }
    }

    // Update is called once per frame
    private void UpdateUI()
    {
        foreach(WayPointController waypoint in data.waypoints)
        {
            waypoint.waypointBaseController.data.item.image.transform.position = UIImagePosition(waypoint.waypointBaseController.data.item);
            waypoint.waypointBaseController.data.item.message.text = WaypointDistance(waypoint.waypointBaseController.data.item) + "m";
        }
    }
}
