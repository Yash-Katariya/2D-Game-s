using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScenes : MonoBehaviour
{
    public void loarscenes(int X)
    {
        SceneManager.LoadScene(X);
    }
    public void UnScenes(int X)
    {
        SceneManager.UnloadScene(X);
    }
}
