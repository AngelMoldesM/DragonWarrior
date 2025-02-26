using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        coinText.text = "Monedas: " + coins;
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador recoge la moneda
        if (other.CompareTag("Player"))
        {
            // Aumentar el contador de monedas del jugador
            other.GetComponent<PlayerController>().AddCoin();

            // Destruir la moneda
            Destroy(gameObject);
        }
    }

    public int GetCoinCount()
    {
        return coins;
    }
}
