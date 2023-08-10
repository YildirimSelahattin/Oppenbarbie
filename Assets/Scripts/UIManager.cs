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

    //
    int explosionRadius = 0;
    float explosionEffectScale = 0;

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
        explosionRadius += 3;
        explosionEffectScale += .33f;
        GameManager.Instance.jetVFX.GetComponent<MeshRenderer>().material.DOFloat(.7f, "_Thrust", 8f);
        beforeLaunchPanel.SetActive(false);
        grid.SetActive(false);
        trajectorySprite.SetActive(false);
        GameManager.Instance.explosionSphere.GetComponent<SphereCollider>().radius = explosionRadius;
        GameManager.Instance.explosionEffect.transform.localScale = new Vector3(explosionEffectScale, explosionEffectScale, explosionEffectScale);
        missile.transform.DORotate(new Vector3(0, -180, 0), 2).OnUpdate(() =>
        {
            missile.transform.DOMoveZ(0, 0).OnComplete(() =>
            {
                MissileController.Instance.speed = 12;
                SwerveMovement.Instance.speed = 12;
            });
        });
        GameManager.Instance.ChangeCamera(GameManager.Instance.followCam, 20);
        SwerveMovement.Instance.GoStartPos();
    }
}
