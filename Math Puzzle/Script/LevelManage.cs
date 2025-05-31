using System;
using UnityEngine;

public class LevelManage : MonoBehaviour
{
    public Sprite[] Lelimage;
    private string[] Answer = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
    public int LevelIndex = 0;

    public GameObject levelSelection, playing;

    public static LevelManage Instance;

    public static int playNowLevelIndex = -1;

    public void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        if(playNowLevelIndex != -1)
        {
            moveToPlaying(playNowLevelIndex);
            playNowLevelIndex = -1;
        }
    }
    public string GetRightAnswer()
    {
        return Answer[LevelIndex];
    }
    public Sprite GetlelImage()
    {
        return Lelimage[LevelIndex];
    }
    public void moveToPlaying(int levelIndex)
    {
        this.LevelIndex = levelIndex;
        levelSelection.SetActive(false);
        playing.SetActive(true);
    }
    public void BackBtn()
    {
        playing.SetActive(false);
        levelSelection.SetActive(true);
    }
    public void nextLevel(string state)
    {
        string currentState = PlayerPrefs.GetString(""+LevelIndex);
        if(currentState != "clear")
        {
            PlayerPrefs.SetString("" + LevelIndex, state);   // Tick Mate And Skip Mate And Loack
        }
        this.LevelIndex++;
        int lastLevel = PlayerPrefs.GetInt("lastLevel", 0);     // Get Kari ne Condition Muki 
        if (lastLevel < LevelIndex)
        {
            PlayerPrefs.SetInt("lastLevel", LevelIndex); // Lastlevel ne Levelindex ma Playprefs.setint kar yu 
        }
    }
}