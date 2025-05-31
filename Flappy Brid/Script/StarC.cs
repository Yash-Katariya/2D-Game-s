using TMPro;
using UnityEngine;

public class StarC : MonoBehaviour
{
    public TMP_Text StarCountText;
    private int StarCount = 0;

    public void Start()
    {
        UpdateCoinCount();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))     // avu check kare che a coin che ke ny 
        {
            //Destroy(collision.gameObject);              // star destroy 
            StarCount++;
            UpdateCoinCount();
        }
    }

    public void UpdateCoinCount()
    {
        StarCountText.text = "" + StarCount.ToString();
    }
}