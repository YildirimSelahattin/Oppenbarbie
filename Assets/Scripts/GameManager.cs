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
    public CinemachineVirtualCamera endCam;

    public GameObject missileSpawnParent;
    public GameObject missillePrefab;
    public GameObject targetPrefab;
    public GameObject missile;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShakeCamera(CinemachineVirtualCamera camera, float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = followCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }

    public void ChangeCamera(CinemachineVirtualCamera camera, int priority)
    {
        camera.Priority = priority;
    }

    public void SpawnMissile()
    {
        missile = Instantiate(missillePrefab, missileSpawnParent.transform);
        UIManager.Instance.trajectorySprite = missile.transform.GetChild(0).gameObject;
        UIManager.Instance.missile = missileSpawnParent.transform.GetChild(0).gameObject;
        UIManager.Instance.slots = UIManager.Instance.missile.transform.GetChild(missile.transform.childCount - 1);

        UIManager.Instance.beforeLaunchPanel.SetActive(true);
        UIManager.Instance.grid.SetActive(true);
        UIManager.Instance.trajectorySprite.SetActive(true);
    }
}