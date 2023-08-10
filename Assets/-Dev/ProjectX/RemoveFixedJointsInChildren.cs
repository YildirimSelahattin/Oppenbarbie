using UnityEngine;

public class RemoveFixedJointsInChildren : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            FixedJoint[] fixedJoints = child.GetComponents<FixedJoint>();

            foreach (FixedJoint joint in fixedJoints)
            {
                Destroy(joint);
            }
        }
    }
}
