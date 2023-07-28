using UnityEngine;

//The base waypoint controller, it handles the waypoint data

[System.Serializable]

public class WaypointBaseController : MonoBehaviour
{
    [System.Serializable]
    public struct Data
    {
        public WayPointItem item;
        public float interactDistance;
        public bool weHaveEffects;
    }

    public Data data;

    public void SetTarget(GameObject target) => data.item.target = target;
    public void SetTransform(Transform transform) => data.item.transform = transform;
    public void SetWayPointEffect(GameObject effect) => data.item.effect = effect;
    public void EffectExist(bool value) => data.weHaveEffects = value;
    public float GetDistance(Vector3 startPosition, Vector3 endPosition) => Vector3.Distance(startPosition,endPosition);

    public void EnableEffect(bool value)
    {
        if (data.weHaveEffects == true) 
        {
            data.item.effect.SetActive(value);
        }
    }

    public void EnableWayPoint(bool value)
    {
        data.item.image.enabled= value;
        data.item.message.enabled= value;
    }

}

