using UnityEngine;
using UnityEngine.UI;

public class InfoTicTacTie : MonoBehaviour
{
    public Vector2Int Size; // X and Y Size 8x8 Grid
    public GameObject But;  // grid na Button ne ganreat karva 
    public Transform BtnParent;  // All Buttton Instantiate thai
    public Text[,] buttontext;
    public Text Wincondition;
    public Text OScorebtn;
    public Text XScorebtn;
    int Coun = 0;
    int OScore = 0;
    int XScore = 0;

    void Start()
    {
        buttontext = new Text[Size.x, Size.y];

        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                GameObject Colne = Instantiate(But, BtnParent); // Btn ne Btnparent Instantiate kare
                Text T = Colne.GetComponentInChildren<Text>(); // Text Used By
                Button B = Colne.GetComponent<Button>();   // Button nu Component                                                       
                buttontext[i, j] = T; // Text ne Button ma Store karva

                B.onClick.AddListener(() =>  // AddListener Button ne add kare
                {
                    if (T.text != "") return; // Button ma Text che to ignore karo

                    if (Coun % 2 == 0)
                    {
                        T.text = "O";
                    }
                    else
                    {
                        T.text = "X";
                    }
                    Coun++;
                    WinCheckbtn();
                });
            }
        }
    }
    public void Restartbtn()
    {
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                buttontext[i, j].text = ""; // Button par na Text khali kari de
            }
        }
        Coun = 0;
        Wincondition.text = "";
        OScorebtn.text = "0";
        XScorebtn.text = "0";
    }
    public void Tiecheck()
    {
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                if (buttontext[i, j].text == "")
                {
                    return;
                }
            }
        }
        if (OScore > XScore)
        {
            Wincondition.text = "O is Win";
        }
        else if (XScore > OScore)
        {
            Wincondition.text = "X is Win";
        } 
        else if (OScore == XScore)
        {
            Wincondition.text = "Game Tie";
        }
    }
    public void WinCheckbtn()
    {
        // ROW 
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y - 3; j++)
            {
                if (buttontext[i, j].text != "" && buttontext[i, j].text == buttontext[i, j + 1].text && buttontext[i, j].text == buttontext[i, j + 2].text && buttontext[i, j].text == buttontext[i, j + 3].text)
                {
                    if (buttontext[i, j].text == "O")
                    {
                        OScore++;
                        OScorebtn.text = " " + OScore;
                    }
                    else if (buttontext[i, j].text == "X")
                    {
                        XScore++;
                        XScorebtn.text = " " + XScore;
                    }
                    buttontext[i, j].text = "";     // Index par Text Remove kari De 
                    buttontext[i, j + 1].text = "";
                    buttontext[i, j + 2].text = "";
                    buttontext[i, j + 3].text = "";
                }
            }
        }
        // Colam 
        for (int i = 0; i < Size.x - 3; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                if (buttontext[i, j].text != "" && buttontext[i, j].text == buttontext[i + 1, j].text && buttontext[i, j].text == buttontext[i + 2, j].text && buttontext[i, j].text == buttontext[i + 3, j].text)
                {
                    if (buttontext[i, j].text == "O")
                    {
                        OScore++;
                        OScorebtn.text = " " + OScore;
                    }
                    else if (buttontext[i, j].text == "X")
                    {
                        XScore++;
                        XScorebtn.text = " " + XScore;
                    }
                    buttontext[i, j].text = "";
                    buttontext[i + 1, j].text = "";
                    buttontext[i + 2, j].text = "";
                    buttontext[i + 3, j].text = "";
                }
            }
        }
        // Dayagolan
        for (int i = 0; i < Size.x - 3; i++)
        {
            for (int j = 0; j < Size.y - 3; j++)
            {
                if (buttontext[i, j].text != "" && buttontext[i, j].text == buttontext[i + 1, j + 1].text && buttontext[i, j].text == buttontext[i + 2, j + 2].text && buttontext[i, j].text == buttontext[i + 3, j + 3].text)
                {
                    if (buttontext[i, j].text == "O")
                    {
                        OScore++;
                        OScorebtn.text = " " + OScore;
                    }
                    else if (buttontext[i, j].text == "X")
                    {
                        XScore++;
                        XScorebtn.text = " " + XScore;
                    }
                    buttontext[i, j].text = "";
                    buttontext[i + 1, j + 1].text = "";
                    buttontext[i + 2, j + 2].text = "";
                    buttontext[i + 3, j + 3].text = "";
                }
            }
        }
        //Anti Dayagolan
        for (int i = 0; i < Size.x - 3; i++)
        {
            for (int j = 3; j < Size.y; j++)
            {
                if (buttontext[i, j].text != "" && buttontext[i, j].text == buttontext[i + 1, j - 1].text && buttontext[i, j].text == buttontext[i + 2, j - 2].text && buttontext[i, j].text == buttontext[i + 3, j - 3].text)
                {
                    if (buttontext[i, j].text == "O")
                    {
                        OScore++;
                        OScorebtn.text = " " + OScore;
                    }
                    else if (buttontext[i, j].text == "X")
                    {
                        XScore++;
                        XScorebtn.text = " " + XScore;
                    }
                    buttontext[i, j].text = "";
                    buttontext[i + 1, j - 1].text = "";
                    buttontext[i + 2, j - 2].text = "";
                    buttontext[i + 3, j - 3].text = "";
                }
            }
        }
        Tiecheck();
    }
}