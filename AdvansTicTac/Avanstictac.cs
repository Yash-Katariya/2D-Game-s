using UnityEngine;
using UnityEngine.UI;

//AdvancedTicTacToe
public class advanstictac : MonoBehaviour
{
    public static Vector2Int Size;
    public GameObject GameP;
    public Transform Gameparent;
    Text[,] btnsText;
    public GridLayoutGroup layoutGroup;
    int Count = 0;
    public Text WinCheck;
    public GameObject PlayPage;
    public GameObject Mainpage;

    public void OnEnable()
    {
        btnsText = new Text[Size.x, Size.y];

        int allchild = Gameparent.childCount;
        for (int i = 0; i < allchild; i++)
        {
            Destroy(Gameparent.GetChild(i).gameObject);
        }

        float Cellsize = (950 / Mathf.Max(Size.x, Size.y)) * .85f;
        layoutGroup.cellSize = new Vector2(Cellsize, Cellsize);

        float spacing = (950 / Mathf.Max(Size.x, Size.y)) * .20f * 2f;
        layoutGroup.spacing = new Vector2(spacing / Size.x, spacing / Size.y);

        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                GameObject clone = Instantiate(GameP, Gameparent);
                Text t = clone.GetComponentInChildren<Text>();
                Button btn = clone.GetComponent<Button>();
                btnsText[i, j] = t;

                btn.onClick.AddListener(() =>
                {
                    if (t.text != "" || WinCheck.text != "") return;

                    if (Count % 2 == 0)
                    {
                        t.text = "O";
                    }
                    else
                    {
                        t.text = "X";
                    }
                    Count++;
                    WinCondition();
                });
            }
        }
    }
    public void PlayHome() // Play to Home Click check Button  
    {
        gameObject.SetActive(false);
        PlayPage.SetActive(true);
    }
    public void HomeMain() // Play to Home Click check Button  
    {
        gameObject.SetActive(false);
        Mainpage.SetActive(true);
    }
    public void ResetGame()
    {
        Count = 0;
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                btnsText[i, j].text = ""; 
            }
        }
        WinCheck.text = "";
    }
    void WinCondition()
    {
        // Col and Row 

        int RowO = 0, RowX = 0;
        int ColO = 0, ColX = 0;

        for (int i = 0; i < Size.x; i++)
        {
            RowO = 0; RowX = 0;
            ColO = 0; ColX = 0;

            for (int j = 0; j < Size.y; j++)
            {
                if (btnsText[i, j].text == "O")
                {
                    RowO++;
                }
                if (btnsText[j, i].text == "O")
                {
                    ColO++;
                }
                if (btnsText[i, j].text == "X")
                {
                    RowX++;
                }
                if (btnsText[j, i].text == "X")
                {
                    ColX++;
                }
            }
            if (RowO == Size.y)
            {
                WinCheck.text = ("O is win");
            }
            if (ColO == Size.x)
            {
                WinCheck.text = ("O is win");
            }
            if (RowX == Size.y)
            {
                WinCheck.text = ("X is win");
            }
            if (ColX == Size.x)
            {
                WinCheck.text = ("X is win");
            }
        }

        // Diagonal

        int diagonalO = 0, diagonalX = 0;

        for (int i = 0; i < Size.x; i++)
        {
            if (btnsText[i, i].text == "O")
            {
                diagonalO++;
            }
            if (btnsText[i, i].text == "X")
            {
                diagonalX++;

            }
        }
        if (diagonalO == Size.x)
        {
            WinCheck.text = ("O is win");
        }
        if (diagonalX == Size.x)
        {
            WinCheck.text = ("X is win");
        }

        // AntiDiagonal

        int antiDiagonalO = 0, antiDiagonalX = 0;
        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                if (i + j == Size.x - 1)
                {
                    if (btnsText[i, j].text == "O")
                    {
                        antiDiagonalO++;
                    }
                    else if (btnsText[i, j].text == "X")
                    {
                        antiDiagonalX++;
                    }
                }
            }
        }
        if (antiDiagonalO == Size.x)
        {
            WinCheck.text = ("O is win");
        }
        if (antiDiagonalX == Size.x)
        {
            WinCheck.text = ("X is win");
        }
    }
} 