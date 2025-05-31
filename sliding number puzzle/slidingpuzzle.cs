using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class slidingpuzzle : MonoBehaviour
{
    public static Vector2Int Sizebtn;
    public GameObject Puzzlebtn;
    public Transform Puzzleparent;
    public Text[,] PuzzleText; 
    public Text Wintext;
    public GridLayoutGroup layoutGroup;
    public Button Resetbtn;
    public  GameObject playpage;
    public GameObject Mainpage;

    public void OnEnable()     //  Function Play To Home and Not Find Error in tha function 
    {    
        int allchild = Puzzleparent.childCount;
        for (int i = 0; i < allchild; i++)
        {
            Destroy(Puzzleparent.GetChild(i).gameObject);
        }

        PuzzleText = new Text[Sizebtn.x, Sizebtn.y];

        float Cellsize = (950 / Mathf.Max(Sizebtn.x, Sizebtn.y)) * .85f;
        layoutGroup.cellSize = new Vector2(Cellsize, Cellsize);
        
        float spacing = (950 / Mathf.Max(Sizebtn.x, Sizebtn.y)) * .20f * 2f;
        layoutGroup.spacing = new Vector2(spacing / Sizebtn.x, spacing / Sizebtn.y);

        List<string> list = getRandomList(); // Random Number Mathod.......

        int num = 0;
        for (int i = 0; i < Sizebtn.x; i++)
        {
            for (int j = 0; j < Sizebtn.y; j++)
            {
                GameObject G = Instantiate(Puzzlebtn, Puzzleparent);
                Text t = G.GetComponentInChildren<Text>();
                Button button = G.GetComponent<Button>();
                PuzzleText[i, j] = t;
                t.text = list[num];
                num++;
                //if (t.text != "" || Wintext.text != "") return;               

                int r = i;
                int c = j;
                button.onClick.AddListener(() => clickbtn(r, c));
                //if (num == Sizebtn.x * Sizebtn.y)
                //if (num == 9) // || Wintext.text != ""
                //{
                //    t.text = "";
                //} 
                //else
                //{
                //    t.text = (num++).ToString();
                //}                
            }
        }
        Resetbtn.onClick.AddListener(Reset);
    }
    private List<string> getRandomList()     // Private Function in Random NUmber Cleam
    {
        List<string> list = new List<string>();

        while (list.Count < Sizebtn.x * Sizebtn.y)
        {
            int randNumber = UnityEngine.Random.Range(0, Sizebtn.x * Sizebtn.y);
            if (!list.Contains(randNumber.ToString()))
            {
                list.Add(randNumber.ToString());
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == "0")
            {
                list[i] = "";
                break;
            }
        }
        return list;
    }   
    public void clickbtn(int r, int c)
    {
        if (r - 1 >= 0 && PuzzleText[r - 1, c].text == "")
        {
            PuzzleText[r - 1, c].text = PuzzleText[r, c].text;
            PuzzleText[r, c].text = "";
        }
        else if (r + 1 < Sizebtn.x && PuzzleText[r + 1, c].text == "")
        {
            PuzzleText[r + 1, c].text = PuzzleText[r, c].text;
            PuzzleText[r, c].text = "";
        }
        else if (c - 1 >= 0 && PuzzleText[r, c - 1].text == "")
        {
            PuzzleText[r, c - 1].text = PuzzleText[r, c].text;
            PuzzleText[r, c].text = "";
        }
        else if (c + 1 < Sizebtn.y && PuzzleText[r, c + 1].text == "")
        {
            PuzzleText[r, c + 1].text = PuzzleText[r, c].text;
            PuzzleText[r, c].text = "";
        }
        Winbtn();
    }    
    public void Winbtn()
    {
        int num = 1;
        for (int i = 0; i < Sizebtn.x; i++)
        {
            for (int j = 0; j < Sizebtn.y; j++)
            {
                if (i == Sizebtn.x - 1 && j == Sizebtn.y - 1)     // 3X3 GRID and i == sizebtn.x - 1 = 2  Ex : grid size 3 and - 1 = 2
                {
                    continue;                                     // loop ma i = 2 and j = 2 thi to if ni bar jay
                }
                if (PuzzleText[i, j].text != num.ToString())
                {
                    return;
                }
                num++;
            }            
        }
        Wintext.text = "You Win";
    }
    public void Playtohome() // Play to Home Click check Button  
    {
        gameObject.SetActive(false);
        playpage.SetActive(true);
    }
    public void Reset()
    {
        List<string> list = getRandomList();  // list mathi Rendom number ly che
        int num = 0;
        for (int i = 0; i < Sizebtn.x; i++)
        {
            for (int j = 0; j < Sizebtn.y; j++)
            {
                PuzzleText[i, j].text = list[num]; // PuzzleText ma Rendom number nakhe che list ma
                num++;
            } 
        }
    }
    public void Gotohome()
    {
        gameObject.SetActive(false);
        Mainpage.SetActive(true);
    }
}