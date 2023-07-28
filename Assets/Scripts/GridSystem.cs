using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    public static GridSystem Instance;
    public GameObject cellPrefab;
    public GameObject gridParent;
    public List<GameObject> gridList;
    public int gridHeight;
    public int gridWidth;
    public float xSize;
    public float ySize;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                GameObject currGrid = Instantiate(cellPrefab, gridParent.transform);
                currGrid.transform.localPosition = new Vector3(x * xSize, 0, -y * ySize);
                gridList.Add(currGrid);
            }
        }
    }

    public void AddPart(GameObject item)
    {
        int rnd = Random.Range(0, gridList.Count);
        int baseRnd = rnd;
        while (true)
        {
            if (gridList[rnd].transform.childCount == 0)
            {
                Instantiate(item, gridList[rnd].transform);
                break;
            }
            else
            {
                rnd++;
                if (rnd >= gridList.Count)
                {
                    rnd = 0;
                }

                if (rnd == baseRnd)
                {
                    //Butonu kapat
                    break;
                }
            }
        }

    }
}
