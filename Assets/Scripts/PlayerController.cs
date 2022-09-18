using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    [SerializeField] Slider HealthSlider;

    public int maxHealth = 5;
    public int currentHealth;

    public float movementSpeed;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        body.MovePosition(body.position+(direction * movementSpeed * Time.deltaTime));
        HealthSlider.value = currentHealth;
    }
    //Player Damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
