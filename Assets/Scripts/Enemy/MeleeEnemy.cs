using System;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
   [SerializeField]private float attackCooldown;

   [SerializeField]private float damage;

    [SerializeField]private float attackRange;
    [SerializeField] private float colliderDistance;

    [SerializeField] private BoxCollider2D boxCollider2D;

    [SerializeField] private LayerMask playerLayer;

    private HealthController playerHealth;
   private float cooldowntimer=Mathf.Infinity;

   private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldowntimer >= attackCooldown){
                cooldowntimer = 0;
                animator.SetTrigger("Attack");
            }
        }

    }

    private bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center + transform.right*attackRange*transform.localScale.x*colliderDistance,
        new Vector3(boxCollider2D.bounds.size.x*attackRange,boxCollider2D.bounds.size.y,boxCollider2D.bounds.size.z), 0f, Vector2.left, 0f,
            playerLayer);
        
        if (hit.collider != null)
        {
            playerHealth = hit.collider.GetComponent<HealthController>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center+ transform.right*attackRange*transform.localScale.x*colliderDistance,  new Vector3(boxCollider2D.bounds.size.x*attackRange,boxCollider2D.bounds.size.y,boxCollider2D.bounds.size.z));      
    }

    private void DamagePlayer(){
        //Debug.Log("DamagePlayer");
        if (PlayerInSight()){
            playerHealth.TakeDamage(damage);
        }
    }
    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
