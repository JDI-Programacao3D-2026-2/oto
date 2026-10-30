using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float attackRange = 2f;      
    public float attackCooldown = 1f;   
    public float damage = 30f;          
   

    private EnemyNavMesh ai;
    private float nextAttackTime;

    void Awake()
    {
        ai = GetComponent<EnemyNavMesh>();
    }

    void Update()
    {
    

        float dist = Vector3.Distance(transform.position, ai.player.position);
        if (dist <= attackRange && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown; 
            Attack();
        }
    }

    void Attack()
    {
        PlayerHealth target = ai.player.GetComponentInParent<PlayerHealth>();
        if (target == null) return;
    }
}