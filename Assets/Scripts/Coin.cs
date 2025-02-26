using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        if (other.CompareTag("Player"))
        {
            CoinController.instance.AddCoin();
            audioManager.PlayCoinPickupSound();
            Destroy(gameObject); // Destruir la moneda al recogerla
        }
    }
}
