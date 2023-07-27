using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    float totalMoney;
    public float incomePer = 1;
    public int currentLevel;
    public int highestLevel;
    public AudioClip uiClickSound;
    public AudioClip sauceSound;
    public AudioClip goldSound;
    public AudioClip iceCreamShot;
    public AudioClip splatSound;
    public AudioSource audioSource;
    public int playSound;
    public int playMusic;
    public int playVibrate;

/*
    public float TotalMoney
    {
        get
        {
            return totalMoney;
        }
        set
        {
            this.totalMoney = value;
            if (UIManager.Instance != null)
            {
                UIManager.Instance.totalMoneyText.text = ((int)value).ToString();
                PlayerPrefs.SetFloat("TotalMoney", totalMoney);
            }
        }
    }
*/

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        LoadData();
        audioSource = GetComponent<AudioSource>();
    }

    public void SaveData()
    {
        //PlayerPrefs.SetFloat("TotalMoney", TotalMoney);
        PlayerPrefs.SetInt("PlaySound", playSound);
        PlayerPrefs.SetInt("PlayMusic", playMusic);
        PlayerPrefs.SetInt("PlayVibrate", playVibrate);
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        if(highestLevel <= currentLevel)
        {
            PlayerPrefs.SetInt("highestLevel", currentLevel);
        }
    }

    public void LoadData()
    {
        //TotalMoney = PlayerPrefs.GetFloat("TotalMoney", 0);
        playSound = PlayerPrefs.GetInt("PlaySound", 1);
        playMusic = PlayerPrefs.GetInt("PlayMusic", 1);
        playVibrate = PlayerPrefs.GetInt("PlayVibrate", 1);
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        highestLevel = PlayerPrefs.GetInt("highestLevel", 1);
    }
}