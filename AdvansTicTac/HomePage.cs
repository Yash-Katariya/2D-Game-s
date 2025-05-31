using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : MonoBehaviour
{
    public GameObject hamepage;

    public void PlayGame(int Size)
    {
        advanstictac.Size = new Vector2Int(Size, Size);
        gameObject.SetActive(false);
        hamepage.SetActive(true);
    }
}
    