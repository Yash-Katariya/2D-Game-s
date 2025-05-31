using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Onelevel : MonoBehaviour
{
    public Transform Answer, questions;
    public GameObject ButtonPrefab;
    public Image levelimage;
    public Button Nextplaybtn;
    public Text Leveltext;
    public int QButtonsize = 12;
    
    Button[] QuestionButton, AnswerButton;

    Dictionary<int, int> Setkey = new Dictionary<int, int>();
   
    public void Start()
    {
        Nextplaybtn.gameObject.SetActive(false);
        Nextplaybtn.onClick.AddListener(() => 
        {
            questions.gameObject.SetActive(true);
            Nextplaybtn.gameObject.SetActive(false);
            LevelManager.Instance.CurrentLevel++;
            OnEnable();
        });
    }

    private void OnEnable()
    {
        CompleteLevel();
        Setkey.Clear();
        levelimage.sprite = LevelManager.Instance.getLevelSprite();
        string RightAnswer = LevelManager.Instance.getRightAnswer();
        string Question = QuestionRendomstring(RightAnswer);

        Removallobject();

        for (int i = 0; i < RightAnswer.Length; i++)
        {
            GameObject clone = Instantiate(ButtonPrefab, Answer);
            Button B = clone.GetComponent<Button>();
            TMP_Text t = clone.GetComponentInChildren<TMP_Text>();
            t.text = "";
            int finalAnswer = i;
            B.onClick.AddListener(() =>
            {
                Answercheck(finalAnswer);
            });
        }

        for (int i = 0; i < Question.Length; i++)
        {
            GameObject clone = Instantiate(ButtonPrefab, questions);
            Button b = clone.GetComponent<Button>();
            TMP_Text t = clone.GetComponentInChildren<TMP_Text>();
            t.text = Question[i].ToString();
            int finalAnswer = i;
            b.onClick.AddListener(() =>
            {
                Questioncheck(finalAnswer);
            });
        }

        QuestionButton = questions.GetComponentsInChildren<Button>();
        AnswerButton = Answer.GetComponentsInChildren<Button>();
    }

    public void CompleteLevel()
    {
        int Count = 1;
        int TotalLevel = LevelManager.Instance.LevelImage.Length;
        for (int i = 0; i < TotalLevel; i++)
        {
            if (PlayerPrefs.GetInt("" + i) == 1)
            {
                Count++;
            }
        }
        Leveltext.text = (LevelManager.Instance.CurrentLevel + 1).ToString();   
    }

    string Alpghabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private string QuestionRendomstring(string RightAnswer) 
    {
        string FinalQuestion = RightAnswer;
        while (FinalQuestion.Length < QButtonsize)
        {
            int RanNumber = UnityEngine.Random.Range(0, Alpghabet.Length);
            FinalQuestion += Alpghabet[RanNumber];
        }
        char[] Tem = FinalQuestion.ToCharArray();
        for (int i = 0; i < Tem.Length; i++)
        { 
            int RanIndex = UnityEngine.Random.Range(0, Tem.Length);
            char T = Tem[i];
            Tem[i] = Tem[RanIndex];
            Tem[RanIndex] = T;
        }
        return new string(Tem);
    }

    private void Removallobject() // This Function is QButtonsize 12 English Worsd 
    {
        if (QuestionButton != null)
        {
            foreach (var clone in QuestionButton)
            {
                DestroyImmediate(clone.gameObject);
            }
        }
        if (AnswerButton != null)
        {
            foreach (var clone in AnswerButton)
            {
                DestroyImmediate(clone.gameObject);
            }
        }
    }

    public void WinChwck()
    {
        string RightAnswer = LevelManager.Instance.getRightAnswer();

        for (int i = 0; i < AnswerButton.Length; i++)
        { 
            TMP_Text T = AnswerButton[i].GetComponentInChildren<TMP_Text>();
            if (RightAnswer[i].ToString() != T.text)
            {
                return;
            }
        }
        print("NEXT PLAY GAME ..........");
        Nextplaybtn.gameObject.SetActive(true);
        questions.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        LevelManager.Instance.LevelCompleted();
        LevelManager.Instance.CurrentLevel++;
        OnEnable();
    }

    private void Questioncheck(int Qindex)
    {
        TMP_Text Qtext = QuestionButton[Qindex].GetComponentInChildren<TMP_Text>();

        for (int i = 0; i < AnswerButton.Length; i++)
        {
            TMP_Text Atext = AnswerButton[i].GetComponentInChildren<TMP_Text>();
            if (Atext.text == "")
            {
                Atext.text = Qtext.text;
                Qtext.text = "";
                Setkey.Add(i, Qindex);
                WinChwck();
                break;
            }
        }
    }
    private void Answercheck(int Aindex)
    {
        int Qindex = Setkey[Aindex];
        Setkey.Remove(Aindex);
        TMP_Text Atext = AnswerButton[Aindex].GetComponentInChildren<TMP_Text>();
        TMP_Text Qtext = QuestionButton[Qindex].GetComponentInChildren<TMP_Text>();
        Qtext.text = Atext.text;
        Atext.text = "";
        //for (int i = 0; i < QuestionButton.Length; i++)
        //{
        //    TMP_Text Qtext = QuestionButton[i].GetComponentInChildren<TMP_Text>();
        //    {
        //        if (Qtext.text == "")
        //        {
        //            Qtext.text = Atext.text;
        //            Atext.text = "";
        //        }
        //    }
        //}
    }
}