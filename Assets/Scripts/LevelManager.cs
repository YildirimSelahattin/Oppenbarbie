using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject planetParent;
    public GameObject[] planets;
    int _currentScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        SpawnPlanet(GameDataManager.Instance.currentLevel - 1);
    }

    public void SpawnPlanet(int levelIndex)
    {
        Instantiate(planets[levelIndex], planetParent.transform);
    }

    public void NextLevel()
    {
        GameDataManager.Instance.currentLevel++;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_currentScene);
    }
}
