using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class pa : MonoBehaviour
{
    public GameObject player;
    public PathCreator cameraPath;
    public EndOfPathInstruction endBehavior;
    public float speed = 1;
    float distanceTravelled;
    public float Xpos;
    public float Zpos;



    public int num;

    void Start()
    {
        transform.position = cameraPath.path.GetPoint(num);
        Debug.Log(transform.position);


    }


    void Update()
    {
        cameraPath.bezierPath.MovePoint(0, new Vector3(Xpos, 0, Zpos));
        cameraPath.bezierPath = cameraPath.bezierPath;
        cameraPath.GetComponent<PathCreation.Examples.RoadMeshCreator>().TriggerUpdate();
    }
}