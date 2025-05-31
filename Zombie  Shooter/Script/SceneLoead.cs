using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoead : MonoBehaviour
{
    public void Sceneload(int Levelindex)
    {
        SceneManager.LoadScene("Level-" + Levelindex);
    }
}
