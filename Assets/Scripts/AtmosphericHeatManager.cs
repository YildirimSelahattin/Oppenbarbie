using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AtmosphericHeatManager : MonoBehaviour
{
    public GameObject atmosphericHeat;

    Material atmosphericHeatMat;

    float change;

    public float thrustMin = 0;
    public float thrustMax;

    public float thrustValue;

    public float thrustChangeTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        atmosphericHeatMat = atmosphericHeat.GetComponent<MeshRenderer>().material;
        atmosphericHeatMat.SetFloat("_Thrust", thrustMin);
        thrustValue = thrustMin;
        UpdateMaterial();
    }

    void ChangeThrustValue(float thrustValueTo)
    {
        thrustValue = thrustValueTo;
        atmosphericHeatMat.SetFloat("_Thrust", thrustValue);
    }

    public void UpdateMaterial()
    {
        DOTween.To(() => change, x => change = x, 1f, thrustChangeTime).SetEase(Ease.Linear)
        .OnUpdate(() =>
        {
            atmosphericHeatMat.SetFloat("_Thrust", change);
        });
    }

    
}
