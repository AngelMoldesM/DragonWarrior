using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
   private AudioManager audioManager;

    [SerializeField] private TextMeshProUGUI winMessageText;
    [SerializeField] private TextMeshProUGUI coinCountText; 
    [SerializeField] private TextMeshProUGUI restartMessageText;
    [SerializeField] private PlayerController playerController; 
    [SerializeField] private CoinController coinController; 

    private bool gameWon = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !gameWon)
        {
            gameWon = true; 

 
            audioManager = FindAnyObjectByType<AudioManager>();
            audioManager.PlayVictorySound();

   
            winMessageText.gameObject.SetActive(true);
            winMessageText.text = "¡Has ganado!";

     
            coinCountText.gameObject.SetActive(true);
            coinCountText.text = "Monedas: " + coinController.GetCoinCount();

   
            restartMessageText.gameObject.SetActive(true);
            restartMessageText.text = "Presiona 'R' para reiniciar o 'Esc' para salir.";

    
            playerController.enabled = false;

 
            DisableAllEnemies();
        }
    }

    private void DisableAllEnemies()
    {
        // Buscar y desactivar todos los enemigos tipo MeleeEnemy
        MeleeEnemy[] enemies = FindObjectsByType<MeleeEnemy>(FindObjectsSortMode.None);
        foreach (MeleeEnemy enemy in enemies)
        {
            enemy.enabled = false;
        }
    }

    private void Update()
    {
        if (gameWon)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar nivel
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit(); // Salir del juego
            }
        }
    }
}
