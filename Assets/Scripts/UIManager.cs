using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button GoButton;

    public Transform Slots;

    public RocketController RocketController;

    public GameObject TrajectorySprite;

    public GameObject BeforeLaunchPanel;

    public GameObject Grid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropBomb()
    {
        foreach (Transform child in Slots.transform)
        {
            child.transform.GetComponent<MeshRenderer>().enabled = false;
        }

        BeforeLaunchPanel.SetActive(false);
        Grid.SetActive(false);
        TrajectorySprite.SetActive(false);
    }
}
