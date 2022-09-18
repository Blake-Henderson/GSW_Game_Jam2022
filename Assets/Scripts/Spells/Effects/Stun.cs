using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    /*
     * turn off movement and shooting
     * update timer until duration turn on move and shoot
     * mew timer for immune to stun
     * when done breing immune destroy this script
     */
    //public List<Color> colors;
    //private void Start()
    //{
    //    gameObject.GetComponent<SpriteRenderer>().color = colors[((int)gameObject.GetComponent<SpellDataManager>().spells[0].type)];
    //}

    public float stunDuration = 1;
    private float stunTimer = 0;
    private float immuneDuration = 1;
    private EnemyAI AI;
    private void Start()
    {
        stunTimer = 0.0f;
        gameObject.TryGetComponent<EnemyAI>(out AI);
        if(AI == null)
            AI.enabled = false;
        else
        {
            Destroy(gameObject.GetComponent<Stun>());
        }
    }
    private void Update()
    {
        stunTimer += Time.deltaTime;
        if (stunTimer >= stunDuration + immuneDuration)
        {
            Destroy(gameObject.GetComponent<Stun>());
        }
        else if (stunTimer >= stunDuration)
        {
            AI.enabled = true;
            
        }
    }
}
