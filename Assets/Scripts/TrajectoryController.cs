using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TrajectoryController : MonoBehaviour
{
    public static TrajectoryController Instance;

    public SpriteShapeController spriteShapeController;

    public Vector3[] positions;

    public int posInt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Update()
    {
        SetSpline();
    }

    public void SetSpline()
    {
        Spline spline = spriteShapeController.spline;
        spline.SetPosition(2, new Vector3(positions[posInt].x, positions[posInt].y, 0));
        Debug.Log(spline.GetPointCount());
        Debug.Log(spline);
        Debug.Log("sda");

        spriteShapeController.RefreshSpriteShape();
    }
}