using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyCars : MonoBehaviour
{
    public GameObject[] Enemycar;
    public float EnemyCarLength;
    public float[] GeneratePosition;
    int LastPosition = 0;

    public void Start()
    {
        InvokeRepeating("Generatecar", 0.5f, 1f);
    }
    void Generatecar()
    {
        Vector3 position = transform.position;
        int Ren = LastPosition;
        while (Ren == LastPosition)
        { 
            Ren = Random.Range(0, GeneratePosition.Length);
        }
        LastPosition = Ren;

        position.x = GeneratePosition[Ren];
        var Carenemy = Enemycar[Random.Range(0, Enemycar.Length)];
        Quaternion rotation = Quaternion.Euler(Carenemy.transform.eulerAngles);
        GameObject DestrouCar = Instantiate(Carenemy, position, rotation);         // Gameobject Destroy karva no Enemy Car
        Destroy(DestrouCar, 5f);
    }
}