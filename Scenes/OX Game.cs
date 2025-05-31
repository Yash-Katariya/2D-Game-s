using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGame : MonoBehaviour
{
    public Text[] btnText;
    int tancount = 0;
    public Text WinText;

    public void TicClick (int buttonIndex)
    {
        if (btnText[buttonIndex].text == "" && WinText.text == "")
        {
            if (tancount % 2 == 0)
            {
                btnText[buttonIndex].text = "O";
            }
            else
            {
                btnText[buttonIndex].text = "X";
            }
            tancount++;
            winCheck();
        }
    }
    public void Resetbutton()
    {
        for(int i = 0; i < btnText.Length; i++)
        {
            btnText[i].text = "";
        }
        WinText.text = "";  
        tancount = 0;   
    }
    public void winCheck()
    {
        if (btnText[0].text == "O" && btnText[1].text == "O" && btnText[2].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[3].text == "O" && btnText[4].text == "O" && btnText[5].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[6].text == "O" && btnText[7].text == "O" && btnText[8].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[0].text == "O" && btnText[4].text == "O" && btnText[6].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[2].text == "O" && btnText[4].text == "O" && btnText[8].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[0].text == "O" && btnText[5].text == "O" && btnText[8].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[1].text == "O" && btnText[4].text == "O" && btnText[7].text == "O")
        {
            WinText.text = "O is win";
        }
        else if (btnText[2].text == "O" && btnText[3].text == "O" && btnText[6].text == "O")
        {
            WinText.text = "O is win";
        }
        else
        if (btnText[0].text == "X" && btnText[1].text == "X" && btnText[2].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[3].text == "X" && btnText[4].text == "X" && btnText[5].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[6].text == "X" && btnText[7].text == "X" && btnText[8].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[0].text == "X" && btnText[4].text == "X" && btnText[6].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[2].text == "X" && btnText[4].text == "X" && btnText[8].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[0].text == "X" && btnText[5].text == "X" && btnText[8].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[1].text == "X" && btnText[4].text == "X" && btnText[7].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[2].text == "X" && btnText[3].text == "X" && btnText[6].text == "X")
        {
            WinText.text = "X is win";
        }
        else if (btnText[0].text != "" && btnText[1].text != "" && btnText[2].text != "" && btnText[3].text != "" && btnText[4].text != "" && btnText[5].text != "" && btnText[6].text != "" && btnText[7].text != "" && btnText[8].text != "")
        {
            WinText.text = "Game Tie";
        }
    }
}