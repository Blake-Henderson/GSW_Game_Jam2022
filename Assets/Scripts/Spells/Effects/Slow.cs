using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Slow : MonoBehaviour
{
    /*
     * start half speed on start
     * upadate until duration is up
     * fix speed delete this script with Destroy(gameObject.GetComponent)
     */
    public float slowTime = 5.0f;
    private EnemyAI AI;
    private float slowTimer = 0;
    private void Start()
    {
        slowTimer = 0;
        gameObject.TryGetComponent<EnemyAI>(out AI);
        if(AI == null)
        {
            Destroy(gameObject.GetComponent<Slow>());
        }
        else
        {
            AI.speed /= 2;
        }
    }
    private void Update()
    {
        slowTimer += Time.deltaTime;
        if(slowTimer >= slowTime)
        {
            AI.speed *= 2;
            Destroy(gameObject.GetComponent<Slow>());
        }
    }
}
