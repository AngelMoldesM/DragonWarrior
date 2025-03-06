using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private HealthController healthController; 

    private void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); 
        }

        if (healthController != null)
        {
            healthController.OnPlayerDeath += ShowGameOverMessage;
        }
    }

    private void Update()
    {

        if (healthController != null && healthController.IsDead && Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    private void ShowGameOverMessage()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); 
        }
    }

    private void RestartScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}