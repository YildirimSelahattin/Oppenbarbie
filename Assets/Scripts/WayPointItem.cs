using UnityEngine;
using UnityEngine.UI;

// Waypoint item data is the data that is added on the waypoint target  game object the target gameobject that needs a waypoint, but also need data to use it.

[System.Serializable]

public struct WayPointItem
{
    public Sprite icone;
    public float distance;
    [HideInInspector] public Image image;
    [HideInInspector] public Text message;
    [HideInInspector] public GameObject effect;
    [HideInInspector] public GameObject waypointUI;
    [HideInInspector] public GameObject target;
    [HideInInspector] public Transform transform;
}
