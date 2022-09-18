using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT : MonoBehaviour
{
    /*
     *need timer
     *max ticks
     *
     *Update
     *do damage on tick
     *lifesteal if can
     *do until max ticks probably 5
     *
     *delete after last tick
     */
    public float tickTime = 1.0f;
    public int maxTicks = 3;
    public int damageMultiplier = 1;
    public bool lifeSteal = false;

    private EnemyAI AI;
    private float tickTimer = 0;
    private int currentTick = 1;

    private void Start()
    {
        tickTimer = 0;
        currentTick = 1;
        gameObject.TryGetComponent<EnemyAI>(out AI);
        if(AI == null)
        {
            Destroy(gameObject.GetComponent<DOT>());
        }
    }
    private void Update()
    {
        tickTimer += Time.deltaTime;
        if(currentTick <= maxTicks && tickTimer < tickTime)
        {
            currentTick++;
            tickTimer = 0;
            AI.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageMultiplier * 1);
            if (lifeSteal && damageMultiplier > 0)
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TakeDamage(-1 * damageMultiplier);
        }
        if(currentTick > maxTicks)
        {
            Destroy(gameObject.GetComponent<DOT>());
        }
    }
}
