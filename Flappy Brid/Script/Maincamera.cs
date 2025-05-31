using UnityEngine;

public class Maincamera : MonoBehaviour
{
    public Transform Brid;
    Vector3 Posi;                                                        // Vector3 = X , Y , Z
    Vector3 Offset;

    void Start()
    {
        Posi = transform.position;
        Offset = transform.position - Brid.position;                     // Main Camera Position - Brid Position = Offset
    }

    void Update()
    {
        Posi.x = Brid.position.x + Offset.x;                             // Brid Position + Offset Position = Posi.x 
        transform.position = Posi;
    }
}
