using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /// <summary>
    /// grabs the element to change the types of the AI
    /// </summary>
    public enum element
    {
        Ather,
        Water,
        Fire,
        Earth,
        Wind
    };

    public element type;
    public int maxHealth = 5;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    /// <summary>
    /// This function deals damage to the user
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        } else if (currentHealth > maxHealth)
                currentHealth = maxHealth;
    }
}
