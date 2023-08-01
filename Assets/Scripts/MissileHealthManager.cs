using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MissileHealthManager : MonoBehaviour
{
    public Image healthBar;

    public float fillAmount;

    public float fuelAmount;

    public float currentFuel;

    public float fuelConsumption;

    public bool fuelConsuming;

    private void Start()
    {
        fillAmount = 1;
        fuelAmount = 1000;

        currentFuel = 1000;

    }

    private void Update()
    {
        if (fuelConsuming)
        {
            ConsumeFuel();

        }
    }

    private void ConsumeFuel()
    {
        currentFuel -= Time.deltaTime * fuelConsumption;

        fillAmount = currentFuel / fuelAmount;

        healthBar.fillAmount = fillAmount;
    }


}
