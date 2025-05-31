using UnityEngine;

public class PipeRepeater : MonoBehaviour
{
    public float Speed;                         
    public float ResetPositionX;         
    public float StartPositionX;

    GameObject Star;

    public void Start()
    {
        Star = transform.GetChild(2).gameObject;
    }
    public void Update()
    {
        if (Bridscript.isGameStarted)
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);                                     // transform.Translate  used to move the position

            if (transform.position.x < ResetPositionX)                                                      // Gameobject position  <  ResetPosition  =>  Gameobject in position < -5 
            {
                transform.position = new Vector2(StartPositionX, transform.position.y);                         // Set the Pipe Position
                if (Random.Range(0, 3) == 0)
                {
                    Star.SetActive(true);
                }
                else
                {
                    Star.SetActive(false);
                }
            }
        }        
    }
}
