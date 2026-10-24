using UnityEngine;
using UnityEngine.Assemblies;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 200f;
    private float currentHealth; 

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("morri :(");
        gameObject.SetActive(false);
    }
}
