using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamepage : MonoBehaviour
{
    public GameObject hamepagePrefab;

    public void Play(int Size)
    {
        slidingpuzzle.Sizebtn = new Vector2Int(Size , Size);
        gameObject.SetActive(false);
        hamepagePrefab.SetActive(true);
    }
}