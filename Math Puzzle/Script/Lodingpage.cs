using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lodingpage : MonoBehaviour
{
    public float WTime = 10.0f;
    bool MP_isPrograssRunning = false;
    public GameObject Loding, playd;

    public void Start()
    {
        StartCoroutine(MovetoLoding());
    } 
    public IEnumerator MovetoLoding()
    {
        yield return new WaitForSeconds(WTime);        
        Loding.SetActive(false);
        playd.SetActive(true);
        MP_isPrograssRunning = true;
    }
    public void NextScene(string Next)
    {
        MP_isPrograssRunning = false;
        SceneManager.LoadScene("LevelSelectionScene");
    }
    public void clickOnPlayNow()
    {
        LevelManage.playNowLevelIndex = PlayerPrefs.GetInt("lastLevel",0);
        SceneManager.LoadScene("LevelSelectionScene");
    }
}