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
        Debug.Log("Colisión con: " + other.gameObject.name);

        if (other.CompareTag("Player") && !gameWon)
        {
            Debug.Log("Jugador alcanzó la meta");

            gameWon = true;
            audioManager = FindAnyObjectByType<AudioManager>();
            audioManager.PlayVictorySound();

            winMessageText.gameObject.SetActive(true);
            coinCountText.gameObject.SetActive(true);
            coinCountText.text = "Monedas: " + coinController.GetCoinCount();

            playerController.enabled = false;
            DisableAllEnemies();

            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                winMessageText.text = "¡Felicidades, has completado el juego!";
                restartMessageText.gameObject.SetActive(true);
                restartMessageText.text = "Presiona 'R' para reiniciar o 'Esc' para salir.";
            }
            else
            {
                Invoke("LoadNextScene", 2f);
            }
        }
    }


    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void DisableAllEnemies()
    {
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Detener el juego en el Editor
#else
        Application.Quit(); // Cerrar el juego en la Build
#endif
            }
        }
    }
}
