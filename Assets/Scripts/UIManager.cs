using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Button goButton;
    public Transform slots;
    public GameObject missile = null;
    public GameObject trajectorySprite;
    public GameObject beforeLaunchPanel;
    public GameObject grid;
    public GameObject restartButon;
    public CinemachineVirtualCamera moveCam;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        GameManager.Instance.SpawnMissile();
        restartButon.GetComponent<Button>().onClick.AddListener(GameManager.Instance.SpawnMissile);
    }

    public void DropBomb()
    {
        beforeLaunchPanel.SetActive(false);
        grid.SetActive(false);
        trajectorySprite.SetActive(false);
        missile.transform.DORotate(new Vector3(0, -180, 0), 2).OnUpdate(() =>
        {
            missile.transform.DOMoveZ(0, 0);
        });
        GameManager.Instance.ChangeCamera(moveCam, 20);
        SwerveMovement.Instance.GoStartPos();
        MissileController.Instance.speed = 12;
        SwerveMovement.Instance.speed = 12;
    }
}
