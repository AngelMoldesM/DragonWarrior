using UnityEngine;
using System; // Necesario para usar eventos

[RequireComponent(typeof(Animator))]
public class HealthController : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float startingHealth; 

    [Header("Components")]
    [SerializeField] private Behaviour[] components; 

    public float CurrentHealth { get; private set; } 
    public bool IsDead { get; private set; } 

    public event Action OnPlayerDeath; 

    private Animator anim;
    private AudioManager audioManager;

    private void Awake()
    {
        CurrentHealth = startingHealth; 
        anim = GetComponent<Animator>(); 
        audioManager = FindAnyObjectByType<AudioManager>(); 
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return; // Si ya está muerto, no hacer nada

        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, startingHealth); 

        if (CurrentHealth > 0)
        {
            
            anim.SetTrigger("hurt");
            audioManager?.PlayHurtSound(); 
        }
        else
        {
            Die(); 
        }
    }

    private void Die()
    {
        if (IsDead) return; 

        IsDead = true;
        anim.SetTrigger("die"); 

        // Desactiva los scripts CUIDAO MATAO!
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }

       
        OnPlayerDeath?.Invoke();
    }

    public void AddHealth(float health)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + health, 0, startingHealth);
    }
}