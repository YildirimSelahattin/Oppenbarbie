using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject gridPrefab;
    GameObject gridParent;
    public List<GameObject> gridList;
    public int gridHeight; 
    public int gridWidth; 
    public float xSize; 
    public float ySize; 

    void Start()
    {
        gridParent = gameObject;
        CreateGrid();
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
}
