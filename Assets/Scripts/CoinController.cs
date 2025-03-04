using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    public TextMeshProUGUI coinText;
    private int coins = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Monedas: " + coins;
    }

    public int GetCoinCount()
    {
        return coins;
    }
}
