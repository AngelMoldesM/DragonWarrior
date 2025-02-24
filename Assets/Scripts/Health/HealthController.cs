using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]private float startingHealth ;
    public float currentHealth{get; private set;}

    private bool dead;

    private Animator anim;

     [Header("Components")]
    [SerializeField] private Behaviour[] components;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void TakeDamage(float _damage)
    {
        currentHealth =Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //iframes?
        }else
        {
            if (!dead)
            {
            anim.SetTrigger("die");
           
           //disable all components
            foreach (Behaviour component in components)
            component.enabled = false;

            dead = true;
            }

        }
    }
    public void AddHealth(float _health)
    {
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startingHealth);
    }
}
