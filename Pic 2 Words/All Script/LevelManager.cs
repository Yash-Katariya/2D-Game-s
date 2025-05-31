using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Sprite[] LevelImage;
    public string[] Allanswer;
    public int CurrentLevel = 0;

    public GameObject Playingpage, Multipull; 

    public static LevelManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    public void Backtomultipull()   // Back Java Mate
    { 
        Playingpage.SetActive(false);
        Multipull.SetActive(true);
    }
    public void Backtoplay()       // Playing Game Mate
    {
        Playingpage.SetActive(true);
        Multipull.SetActive(false);
    }
    public string getRightAnswer()
    { 
        return Allanswer[CurrentLevel];
    }
    public Sprite getLevelSprite()
    {
        return LevelImage[CurrentLevel];
    }
    public void LevelCompleted()      // Levet Text => 1,2,3,4,5 ..........
    {
        // 0->false, 1->true
        PlayerPrefs.SetInt("" + CurrentLevel, 1);
    }
}
