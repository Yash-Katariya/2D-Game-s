using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LodingSystem : MonoBehaviour
{
    public GameObject Playing, Intro;
    public Image Fillimage;
    bool isPrograssRunning = false;  // Loding Mate
    public float WaitTime = 10.0f;

    public void Start()
    {
        StartCoroutine(MoveToPlayingWithDelay());   
    }
    private IEnumerator MoveToPlayingWithDelay()
    {
        //print("Start............");
        yield return new WaitForSeconds(2); // Second 
        //print("End............");
        Playing.SetActive(true);
        Intro.SetActive(false);
        isPrograssRunning = true;
    }

    public void Update()
    {
        if (isPrograssRunning)
        { 
            if(Fillimage.fillAmount < 1)
            {
                Fillimage.fillAmount += 1.0f / WaitTime * Time.deltaTime;
            }
            else
            {
                isPrograssRunning = false;
                SceneManager.LoadScene("Multilevelscreen"); // Je Scenes ne Muk Vi hoy to tenu nmae Lakh vanu 
            }
            //print("Delta Score => " + Time.deltaTime);
        }
    }
    //private void StartImageFill()
    //{
    //    float i = 0;

    //    while (i <= 1)
    //    {
    //        Fillimage.fillAmount = i;
    //        i += 0.01f;
    //    }     
    //}
}
