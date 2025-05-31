using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public GameObject LevelPage, Home;

    public void Playing()
    {
        Home.SetActive(false);
        LevelPage.SetActive(true);
    }
}