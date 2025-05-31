using UnityEngine;

public class Zombieandbullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;
    public int collisionCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        lastVelocity = rb.linearVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var force = lastVelocity.magnitude;
        Vector2 reflection = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        float angle = Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        rb.linearVelocity = reflection * force;
        collisionCount--;
        if (collisionCount == 0)
        {
            gameObject.SetActive(false);

            int totalBullet = GameObject.FindGameObjectsWithTag("Bullet").Length;
            int totalZombie = GameObject.FindGameObjectsWithTag("zombie").Length;
            print(totalBullet);
            if (totalBullet == 0 && totalZombie != 0)
            {
                Gmanager.Instance.openGameOverPage();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "zombie")
        {
            collision.gameObject.SetActive(false);
            //Animator animator = collision.gameObject.GetComponent<Animator>();
            //animator.SetTrigger("death");
            Destroy(collision.gameObject, 2);
            int totalZombie = GameObject.FindGameObjectsWithTag("zombie").Length;
            print(totalZombie);
            if (totalZombie == 0)
            {
                print("game win");
                Gmanager.Instance.openWinPage();
            }
        }
    }
}