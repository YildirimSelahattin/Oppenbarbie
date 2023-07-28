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
    public List<GameObject> Wings;
    public List<GameObject> Heads;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        addPartBtn.onClick.AddListener(AddPart);
        addLevelBtn.onClick.AddListener(AddLevel);
    }

    public void AddPart()
    {
        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            if (GameDataManager.Instance.currentLevel < Wings.Count)
            {
                GridSystem.Instance.AddPart(Heads[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(Heads[Wings.Count-1]);
            }
        }
        else if (rnd == 1)
        {
            if (GameDataManager.Instance.currentLevel < Wings.Count)
            {
                GridSystem.Instance.AddPart(Wings[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(Wings[Wings.Count-1]);
            }
        }
        else if (rnd == 2)
        {
            if (GameDataManager.Instance.currentLevel < Wings.Count)
            {
                GridSystem.Instance.AddPart(Nozzles[GameDataManager.Instance.currentLevel - 1]);
            }
            else
            {
                GridSystem.Instance.AddPart(Nozzles[Wings.Count-1]);
            }
        }
    }

    public void AddLevel()
    {
        GameDataManager.Instance.currentLevel++;
    }
}