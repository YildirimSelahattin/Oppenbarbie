using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class BombData : MonoBehaviour
{
    public static BombData Instance;
    public float Potency = 0.1f;
    public float Speed = 1;
    public GameObject[] BasicWarHeads;
    public GameObject[] DrillWarHeads;
    public GameObject[] Nozzles;
    public GameObject[] Wings;
    public GameObject HeadParent;
    public GameObject WingParent;
    public GameObject NozzleLParent;
    public GameObject NozzleRParent;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
