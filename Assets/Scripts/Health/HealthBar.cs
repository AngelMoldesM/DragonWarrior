using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar Settings")]
    [SerializeField] private HealthController healthController; 
    [SerializeField] private Image totalHealthBar; 
    [SerializeField] private Image currentHealthBar; 

    private const int MAX_HEARTS = 10; 

    private void Start()
    {
        totalHealthBar.fillAmount = healthController.CurrentHealth / MAX_HEARTS;

        currentHealthBar.fillAmount = healthController.CurrentHealth / MAX_HEARTS;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = healthController.CurrentHealth / MAX_HEARTS;
    }
}