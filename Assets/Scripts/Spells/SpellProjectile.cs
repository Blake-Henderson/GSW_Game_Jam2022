using System.Collections;
using System.Collections.Generic;
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
    public float speed;
    /// <summary>
    /// used for properly coloring the projectiles
    /// </summary>
    public List<Color> colors;
    /// <summary>
    /// Rigidbody of the projectile
    /// </summary>
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //move
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //the switch for effects AOE->DOT->Stun->Slow->Life steal
            //attach relvent scripts to enemy
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
