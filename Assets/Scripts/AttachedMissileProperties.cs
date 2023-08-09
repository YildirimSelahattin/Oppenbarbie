using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedMissileProperties : MonoBehaviour
{
    public enum NozzlePos { Left, Center, Right};
    public NozzlePos nozzlePosition;
    public int partLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        Debug.Log("Pressed");
    }
}
