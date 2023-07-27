using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    public GameObject gridPrefab;
    GameObject gridParent;
    public List<GameObject> gridList;
    public int gridHeight;
    public int gridWidth;
    public float xSize;
    public float ySize;
    public GameObject obj;
    public Button btn;

    void Start()
    {
        gridParent = gameObject;
        CreateGrid();

        btn.onClick.AddListener(AddPart);
    }

    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                GameObject currGrid = Instantiate(gridPrefab, gridParent.transform);
                currGrid.transform.localPosition = new Vector3(x * xSize, 0, -y * ySize);
                gridList.Add(currGrid);
            }
        }
    }

    void AddPart()
    {
        int rnd = Random.RandomRange(0, gridList.Count);
        int baseRnd = rnd;
        while (true)
        {
            if (gridList[rnd].transform.childCount == 0)
            {
                Instantiate(obj, gridList[rnd].transform);
                break;
            }
            else
            {
                rnd++;
                if(rnd >= gridList.Count)
                {
                    rnd = 0;
                }

                if(rnd == baseRnd)
                {
                    //Butonu kapat
                    break;
                }
            }
        }

    }
}
