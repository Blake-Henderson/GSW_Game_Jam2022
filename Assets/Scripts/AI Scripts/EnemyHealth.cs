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
    public SpriteRenderer sprite;
    public element type;
    public int maxHealth = 20;
    public int currentHealth;
    public List<Color> colors;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sprite.color = colors[(int)type];
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
