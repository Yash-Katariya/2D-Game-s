using UnityEngine;

public class Playpage : MonoBehaviour
{
    public GameObject Homebutton;

    public void Playgame()
    {
        gameObject.SetActive(false);
        Homebutton.SetActive(true);
    }
}
