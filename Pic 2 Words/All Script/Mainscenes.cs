using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscenes : MonoBehaviour
{
    public void Loardscenes(string Y)
    {
        SceneManager.LoadSceneAsync(Y);    
    }
}