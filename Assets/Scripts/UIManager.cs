using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UIManager : MonoBehaviour
{
    public Button GoButton;

    public Transform Slots;

    public GameObject Missile;

    public GameObject TrajectorySprite;

    public GameObject BeforeLaunchPanel;

    public GameObject Grid;
    public CinemachineVirtualCamera moveCam;

    public void DropBomb()
    {
        foreach (Transform child in Slots.transform)
        {
            child.transform.GetComponent<MeshRenderer>().enabled = false;
        }

        BeforeLaunchPanel.SetActive(false);
        Grid.SetActive(false);
        TrajectorySprite.SetActive(false);
        Missile.GetComponent<MissileController>().enabled = true;
        ChangeCamera(moveCam,20);
    }

    public void ChangeCamera(CinemachineVirtualCamera camera, int priority)
    {
        camera.Priority = priority;
    }
}
