using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinPage : MonoBehaviour
{
    public GameObject MainManu, Coutinue;

    public void MainManubtn()
    {
        MainManu.SetActive(true);
        //Time.timeScale = 0f;
    }
}
