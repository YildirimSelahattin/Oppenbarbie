using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public Button addPartBtn;
    public Button addLevelBtn; //
    public List<GameObject> Nozzles;
    public List<GameObject> WingDs;
    public List<GameObject> Heads;
    public List<GameObject> WingUs;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        addPartBtn.onClick.AddListener(delegate { AddPart(10); });

        addLevelBtn.onClick.AddListener(AddLevel);
    }

    public void AddPart(int rnd)
    {
        if (rnd == 10)
        {
            rnd = Random.Range(0, 4);
        }

        if (rnd == 0)
        {
            if (GameDataManager.Instance.currentLevel < WingDs.Count)
            {
                GridSystem.Instance.AddPart(Heads[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(Heads[WingDs.Count - 1]);
            }
        }
        else if (rnd == 1)
        {
            if (GameDataManager.Instance.currentLevel < WingDs.Count)
            {
                GridSystem.Instance.AddPart(WingDs[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(WingDs[WingDs.Count - 1]);
            }
        }
        else if (rnd == 2)
        {
            if (GameDataManager.Instance.currentLevel < WingDs.Count)
            {
                GridSystem.Instance.AddPart(Nozzles[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(Nozzles[WingDs.Count - 1]);
            }
        }
        else if (rnd == 3)
        {
            if (GameDataManager.Instance.currentLevel < WingDs.Count)
            {
                GridSystem.Instance.AddPart(WingUs[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(WingUs[WingDs.Count - 1]);
            }
        }
    }

    public void AddLevel()
    {
        GameDataManager.Instance.currentLevel++;
    }
}
