using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Button goButton;

    public Transform slots;

    public GameObject missile;

    public GameObject trajectorySprite;

    public GameObject beforeLaunchPanel;

    public GameObject grid;
    public CinemachineVirtualCamera moveCam;

    public void DropBomb()
    {
        /*
        foreach (Transform child in slots.transform)
        {
            child.transform.GetComponent<MeshRenderer>().enabled = false;
        }
        */
        beforeLaunchPanel.SetActive(false);
        grid.SetActive(false);
        trajectorySprite.SetActive(false);
        missile.GetComponent<MissileController>().enabled = true;
        missile.transform.DORotate(new Vector3(0, -180, 0), 2).OnUpdate(() =>
        {
            missile.transform.DOMoveZ(0,0);
        });
        GameManager.Instance.ChangeCamera(moveCam,20);
        SwerveMovement.Instance.GoStartPos();
        SwerveMovement.Instance.speed = 2;
    }
}
