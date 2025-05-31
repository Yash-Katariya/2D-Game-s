using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;
    Vector3 Postn;

    void Start()
    {
        Postn = transform.position;    
    }

    void Update()
    {
        Postn.y -= Speed * Time.deltaTime;
        transform.position = Postn;  
    }
}