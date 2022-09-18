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

    public bool stun;
    public bool slow;
    public bool dot;
    public bool lifeSteal;
    public int damageMultipler = 1;
    public ParticleSystem particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dot)
        {
            if(collision.gameObject.GetComponent<DOT>() == null)
            {
                collision.gameObject.AddComponent<DOT>();
                collision.gameObject.GetComponent<DOT>().lifeSteal = lifeSteal;
                collision.gameObject.GetComponent<DOT>().damageMultiplier = damageMultipler;
            }
        }
        if(slow)
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
    private void Update()
    {
        if (!particles.isEmitting)
        {
            Destroy(gameObject);
        }
    }
}
