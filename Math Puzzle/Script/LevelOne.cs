using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOne : MonoBehaviour
{
    public Text Numbertext;
    public Image levelImage;
    public TMP_Text title;
    public LevelManage levelManage;
    public GameObject PlayingGame, WinPage, puzzleSelection;

    public void OnEnable()
    {
        levelImage.sprite = levelManage.GetlelImage();
        title.text = "Level " + (levelManage.LevelIndex + 1).ToString();
    }
    public void Number(string Value)
    {
        Numbertext.text += Value;
    }

    public void IcnoRemove()
    {
        if (Numbertext.text.Length > 0)
        {
            Numbertext.text = Numbertext.text.Remove(Numbertext.text.Length - 1, 1);
        }
    }
    public void CountinueBtn()
    {
        WinPage.SetActive(false);
        PlayingGame.SetActive(true);
    }

    public void MainManuBtn()
    {
        puzzleSelection.SetActive(true);
        WinPage.SetActive(false);
    }

    public void onClickSubmit()
    {
        string rightAnswer = levelManage.GetRightAnswer();
        string userAnswer = Numbertext.text;
        if (rightAnswer == userAnswer)
        {
            levelManage.nextLevel("clear");  // Next Level Mate..........
            PlayingGame.SetActive(false);
            WinPage.SetActive(true);
            Numbertext.text = "";
            OnEnable();
        }
        else
        {
            print(" WRONG ANSWER ................");
            Numbertext.text = "";
        }
    }

    public void clickOnSkip()
    {
        levelManage.nextLevel("skip");
        OnEnable();
    }
}