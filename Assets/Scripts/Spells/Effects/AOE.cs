using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    /*
     * 
     * pull in stats
     * IN TRIGGER ENTER
     * see if DOT
     * yes apply DOT to all enemies
     * 
     * See if stun
     * yes stun all enemies
     * 
     * see of slow 
     * yes slow all enemies
     * 
     * see if life steal
     * heal enemies
     */
    /// <summary>
    /// The spell's data
    /// </summary>
    public Spell data;
    /// <summary>
    /// used for properly coloring the projectiles
    /// </summary>
    public List<Color> colors;

    public bool stun = false;
    public bool slow = false;
    public bool dot = false;
    public bool lifeSteal = false;
    public int damageMultipler = 1;
    public float lifeTime = 1.0f;
    public List<ParticleSystem> particles;
    private ParticleSystem particle;

    private float timer = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (dot)
            {
                if (collision.gameObject.GetComponent<DOT>() == null)
                {
                    collision.gameObject.AddComponent<DOT>();
                    collision.gameObject.GetComponent<DOT>().lifeSteal = lifeSteal;
                    collision.gameObject.GetComponent<DOT>().damageMultiplier = damageMultipler;
                }
            }
            if (slow)
            {
                if (collision.gameObject.GetComponent<Slow>() == null)
                {
                    collision.gameObject.AddComponent<Slow>();
                }
            }
            if (stun)
            {
                if (collision.gameObject.GetComponent<Stun>() == null)
                {
                    collision.gameObject.AddComponent<Stun>();
                }
            }
            if (lifeSteal)
            {

            }
        }

    }
    private void Start()
    {
        timer = 0;
        particle = particles[(int)data.type];

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (!particle.isEmitting && timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
