using TMPro;
using UnityEngine;

public class CoinCllect : MonoBehaviour
{
    public TMP_Text coinCountText;
    private int coinCount = 0;

    public void Start()
    {
        UpdateCoinCount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))     // avu check kare che a coin che ke ny 
        {
            Destroy(collision.gameObject);              // coin destroy 
            coinCount++;
            UpdateCoinCount();
        }
    }

    public void UpdateCoinCount()
    {
        coinCountText.text = "Coins : " + coinCount.ToString();
    }
}