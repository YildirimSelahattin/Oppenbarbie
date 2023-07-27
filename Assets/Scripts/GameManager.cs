using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CinemachineVirtualCamera followCam;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShakeCamera(float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = followCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
}