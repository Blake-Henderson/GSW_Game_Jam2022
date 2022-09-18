using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    /// <summary>
    /// The spell's data
    /// </summary>
    public Spell data;
    /// <summary>
    /// Speed of the projectile
    /// </summary>
    public float speed = 5.0f;
    /// <summary>
    /// used for properly coloring the projectiles
    /// </summary>
    public List<Color> colors;
    public GameObject AOEPrefab;
    public SpriteRenderer sprite;
    /// <summary>
    /// Rigidbody of the projectile
    /// </summary>
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite.color = colors[(int)data.type];
    }

    private void Update()
    {
        rb.velocity = speed * gameObject.transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int damage = data.getDamage(collision.gameObject);
            if (data.effects == Spell.specialEffects.AOE)
            {
                GameObject temp = Instantiate(AOEPrefab, gameObject.transform.position, Quaternion.identity);
                AOE AOEData = temp.GetComponent<AOE>();
                AOEData.data = data;
                AOEData.damageMultipler = damage;
                //stuff to add in for multiple effects
            }
            else
            {
                if (data.effects == Spell.specialEffects.DOT)
                {
                    if (collision.gameObject.GetComponent<DOT>() == null)
                    {                       
                        DOT temp = collision.AddComponent<DOT>();
                        //check if also lifesteal
                    }
                }
                if (data.effects == Spell.specialEffects.LifeSteal)
                {
                    if (damage > 0)
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TakeDamage(-1 * damage);
                }
                if (data.effects == Spell.specialEffects.Stun)
                {
                    if (collision.gameObject.GetComponent<Stun>() == null)
                    {
                        collision.gameObject.AddComponent<Stun>();
                    }
                }
                if (data.effects == Spell.specialEffects.Slow)
                {
                    if (collision.gameObject.GetComponent<Slow>() == null)
                    {
                        collision.gameObject.AddComponent<Slow>();
                    }
                }
            }
        }
        if(collision.tag != "Player")
        {
            Destroy(gameObject);
        }        
    }
}
