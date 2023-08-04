using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketTrailManager : MonoBehaviour
{

    Material rocketTrailMat;

    float change;

    public float thrustMin = 0;
    public float thrustMax;

    public float thrustValue;

    public float thrustChangeTime = 3;

    public bool accelerating;


    // Start is called before the first frame update
    void Start()
    {
        rocketTrailMat = GetComponent<MeshRenderer>().material;
        rocketTrailMat.SetFloat("_Thrust", thrustMin);
        thrustValue = thrustMin;
        //accelerating = RocketManager.Instance.accelerating;
    }
/*
    private void Update()
    {
        if (RocketManager.Instance.accelerating == true)
        {
            Debug.Log("acc1");

            if (accelerating != true)
            {
                Debug.Log("acc");
                accelerating = true;
                DOTween.Kill("TrailDown");
                UpdateMaterial();
            }
            
        }

        else
        {
            Debug.Log("dec1");

            if (accelerating != false)
            {
                Debug.Log("dec");
                accelerating = false;
                DOTween.Kill("TrailUp");
                UpdateMaterial2();
            }
                
        }
    }
    void ChangeThrustValue(float thrustValueTo)
    {
        thrustValue = thrustValueTo;
        rocketTrailMat.SetFloat("_Thrust", thrustValue);
    }

    void UpdateMaterial()
    {
        DOTween.To(() => change, x => change = x, 1, thrustChangeTime).SetEase(Ease.Linear).SetId("TrailUp")
        .OnUpdate(() =>
        {
            rocketTrailMat.SetFloat("_Thrust", change);
        });
    }

    void UpdateMaterial2()
    {
        DOTween.To(() => change, x => change = x, 0, thrustChangeTime).SetEase(Ease.Linear).SetId("TrailDown")
        .OnUpdate(() =>
        {
            rocketTrailMat.SetFloat("_Thrust", change);
        });
    }
    */
}
