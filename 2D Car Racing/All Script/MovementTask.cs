using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementTask : MonoBehaviour
{
    public float speed;
    public GameObject Playing, Gameover;

    void Update()
    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos.x += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos.y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos.y -= speed * Time.deltaTime;
        }
        // Mathf.Clamo(float value, float min, float Max)
        newPos.x = Mathf.Clamp(newPos.x, -1.92f, 1.92f);
        newPos.y = Mathf.Clamp(newPos.y, -4.22f, 4.22f);
        transform.position = newPos;    
    }   

    public void OnCollisionEnter2D()
    {
        //Playing.SetActive(false);
        Gameover.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CarRacing");
    }
}