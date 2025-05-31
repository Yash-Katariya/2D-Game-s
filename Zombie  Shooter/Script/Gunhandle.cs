using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GunScrip : MonoBehaviour
{
    public Transform AimSet;
    public GameObject BulletPrefab;
    public int maxBullets = 5;     
    private int currentBullets = 0;
    //public GameObject NextPage;

    public Image[] Bulleui;

    private void Start()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            Bulleui[i].enabled = true;
        }
    }

    void Update()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);                         // Used To Mouse Position 
        MousePosition.z = 0;
        AimSet.position = MousePosition;                                                                     // Aim Position To Mouse Position 

        Vector3 OffSet = MousePosition - transform.position;                                                 // Mouse Position Check 
        float Angle = Mathf.Atan2(OffSet.y, OffSet.x) * Mathf.Rad2Deg; // Mathf.Rad2Deg = This will output 1 radians are equal to 57.29578 degrees 
                                                                                                             // Gun And Aim difference Check
        transform.rotation = Quaternion.Euler(0, 0,Angle);                                                   // 0, 0, Angle = transform.rotation

        if (Input.GetMouseButtonDown(0))
        {
            Fire(Angle);
        }
    }
    private void Fire(float Angle)
    {
        if (currentBullets >= maxBullets)
        {
            print("No More Bullet.....");
            //NextPage.SetActive(true);
            return;
        }

        var Pos = transform.position;                                                                      // Position 
        var Rotete = Quaternion.Euler(0, 0, Angle + 90);                                                   // Angle
        var Clone = Instantiate(BulletPrefab, Pos, Rotete, transform.parent);                              // Set The Clone Instantiate
        var Rb = Clone.GetComponent<Rigidbody2D>();                                                        // Rigidbody2D 

        var MyPosition = Camera.main.WorldToScreenPoint(transform.position);                               // Bullet In Camera Scene
        var direction = Input.mousePosition - MyPosition;                                                  // Mous Click and Set this My position

        Rb.AddForce(direction.normalized * 600);                                                           // Bullet Force line
        currentBullets++;
        UpdateBullet();
    }

    public void UpdateBullet ()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            if (i >= currentBullets)
            {
                Bulleui[i].gameObject.SetActive(true);
            }
            else
            {
                Bulleui[i].gameObject.SetActive(false);
            }
        }
    }
    public void BulletDestroyed()
    {
        currentBullets--;
        UpdateBullet();
    }
}