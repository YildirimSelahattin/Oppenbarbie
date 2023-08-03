using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TrajectoryController : MonoBehaviour
{
    public static TrajectoryController Instance;

    public SpriteShapeController spriteShapeController;

    public Vector3[] trajectories;

    public int trajLv;

    public int trajDir;

    public int nozzleBalance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {
        SetSpline(1, 0);
    }

    public void Update()
    {
    }

    public void SetSpline(int trajDir, int trajLv)
    {
        Spline spline = spriteShapeController.spline;
        spline.SetPosition(2, new Vector3(trajDir * trajectories[trajLv].x, trajectories[trajLv].y, 0));

        spriteShapeController.RefreshSpriteShape();
    }


    public void CalculateNozzlesBalance(string nozzlePosition, int weight)
    {
        if (nozzlePosition == "Right")
        {
            nozzleBalance += weight;
        }

        if (nozzlePosition == "Left")
        {
            nozzleBalance -= weight;
        }

        Debug.LogError("Balance " + nozzleBalance);
        SetSpline( (int)Mathf.Sign(nozzleBalance), Mathf.Abs(nozzleBalance));
    }

}