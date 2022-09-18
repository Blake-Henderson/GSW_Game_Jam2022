using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeSpell : MonoBehaviour
{
    /// <summary>
    /// The spell's data
    /// </summary>
    public Spell data;
    /// <summary>
    /// used for properly coloring the projectiles
    /// </summary>
    public List<Color> colors;
    public float lifeSpan = 0.5f;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite.color = colors[(int)data.type];
        Destroy(gameObject, lifeSpan);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int damage = data.getDamage(collision.gameObject);
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
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
