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
    public CinemachineVirtualCamera startCam;
    public CinemachineVirtualCamera endCam;
    public GameObject missileSpawnParent;
    public GameObject missillePrefab;
    public GameObject targetPrefab;
    public GameObject missile;
    public GameObject explosionSphere;
    public GameObject explosionEffect;
    public GameObject jetVFX;

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
        UIManager.Instance.missile = missileSpawnParent.transform.GetChild(0).gameObject;
        explosionSphere = missileSpawnParent.transform.GetChild(0).transform.GetChild(missileSpawnParent.transform.GetChild(0).childCount - 1).gameObject;
        explosionEffect = missileSpawnParent.transform.GetChild(0).transform.GetChild(missileSpawnParent.transform.GetChild(0).childCount - 2).gameObject;
        jetVFX = missileSpawnParent.transform.GetChild(0).transform.GetChild(missileSpawnParent.transform.GetChild(0).childCount - 3).gameObject;
        followCam.LookAt = missile.transform;
        startCam.LookAt = missile.transform;
        //endCam.LookAt = missile.transform;
        followCam.Follow = missile.transform;
        startCam.Follow = missile.transform;
        //endCam.Follow = missile.transform;
        followCam.Priority = 5;
        startCam.Priority = 10;
        endCam.Priority = 0;
        UIManager.Instance.beforeLaunchPanel.SetActive(true);
        UIManager.Instance.grid.SetActive(true);
        UIManager.Instance.trajectorySprite.SetActive(true);
    }
}