using TMPro;
using UnityEngine;

public class GoalController : MonoBehaviour
{
private AudioManager audioManager;
   [SerializeField] public TextMeshProUGUI winMessageText;  // Referencia al texto que muestra el mensaje
    [SerializeField] public TextMeshProUGUI coinCountText;   // Referencia al texto que muestra las monedas
    [SerializeField] public PlayerController playerController; // Referencia al jugador

    [SerializeField] CoinController coinController;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            audioManager = FindAnyObjectByType<AudioManager>();
            audioManager.PlayVictorySound();
            winMessageText.gameObject.SetActive(true);
            winMessageText.text = "¡Has ganado!";


            coinCountText.gameObject.SetActive(true);
            coinCountText.text = "Monedas: " + coinController.GetCoinCount();


            playerController.enabled = true;

        }
    }
}
