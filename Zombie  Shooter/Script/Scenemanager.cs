using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public void Resetbtn()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void SecondResetbtn()
    {
        SceneManager.LoadScene("Level-2");
    }
    public void TResetbtn()
    {
        SceneManager.LoadScene("Level-3");
    }
}
