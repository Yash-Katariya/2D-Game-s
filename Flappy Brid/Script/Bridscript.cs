using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bridscript : MonoBehaviour
{
    public float JumpForce;
    Rigidbody2D Rb;
    public GameObject Play, Reset, Started;

    public static bool isGameStarted = false;

    void Start()
    {
        isGameStarted = false;  
        Rb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        if (isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rb.linearVelocityY = JumpForce;
            }
        }        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Reset.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            collision.gameObject.SetActive(false);
        }
    }
    public void Startbtn()  
    {
        Time.timeScale = 1f;
        Started.SetActive(false);
        isGameStarted = true;
        Rb.isKinematic = false;
        Play.SetActive(true);
    }
    public void Resetbtn()
    {
        SceneManager.LoadScene("Flappybrid");
        Time.timeScale = 0f;
    }  
}
