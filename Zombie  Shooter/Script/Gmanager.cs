using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gmanager : MonoBehaviour
{
    public GameObject Win, Over;
    public static int Currentlevel = 1;

    public static Gmanager Instance;

    public void Awake()
    {
        Instance = this;
    }
   
    public void openWinPage()
    {
        StartCoroutine(_openWinPage());
    }
    private IEnumerator _openWinPage()
    {
        yield return new WaitForSeconds(2f);
        Win.SetActive(true);
    }
    public void openGameOverPage()
    {
        StartCoroutine(_openGameOverPage());
    }
    public IEnumerator _openGameOverPage()
    {
        yield return new WaitForSeconds(1.5f);
        Over.SetActive(true);
    }
}