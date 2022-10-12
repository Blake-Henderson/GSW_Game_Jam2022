using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject enemyProjectilePrefab;
    public GameObject target;
    public EnemyHealth health;
    public Rigidbody2D rd;


    public float coolDown = 1f;
    public float attacktimer = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        attacktimer = 0f;
        
    }

    void Shoot()
    {
        EnemyAI e = transform.parent.GetComponent<EnemyAI>();
        if (!e.hasLineOfSight)
            return;
        GameObject temp = Instantiate(enemyProjectilePrefab, firePoint.position, firePoint.rotation);
        rd = temp.GetComponent<Rigidbody2D>();
        //rd.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        temp.GetComponent<EnemyBullet>().colorIndex = (int)(health.type);
        attacktimer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
         Vector2 lookDir = (Vector2)target.transform.position - rb.position;
         float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
         rb.rotation = angle;
        
        attacktimer += Time.deltaTime;
        if (attacktimer >= coolDown)
        {
            attacktimer = 0f;
            Shoot();           
        }

    }
}
