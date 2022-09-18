using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] float rayObjectDistance;

    public LayerMask LayerMask;
    public Transform target;
    public Transform firePoint;
    public GameObject enemyProjectilePrefab;
    public GameObject rayObject;
    private GameObject targetObj;

    public float bulletForce = 20f;
    public float coolDown = 0f;
    public float attacktimer = 0f;
    public float speed = 100f;
    public float nextWaypointDistance = 5f;


    Path path;
    float aiDirection;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        aiDirection = 0f;
        attacktimer = 0f;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Shoot()
    {
        GameObject temp = Instantiate(enemyProjectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rd = temp.GetComponent<Rigidbody2D>();
        rd.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //temp.GetComponent<EnemyBullet>().colorIndex = (int)gameObject.GetComponent<EnemyHealth>.type;

    }

    // FixedUpdate is called once every few frames
    void FixedUpdate()
    {
        attacktimer = Time.deltaTime;
        if (attacktimer >= coolDown)
        {
            Shoot();    
            attacktimer = 0f;
        }
        
        Vector2 targetPos = target.position;
        Vector2 Direction = targetPos - (Vector2)transform.position;
        
        RaycastHit2D hit = Physics2D.Raycast(rayObject.transform.position, Direction);

        Debug.DrawRay(rayObject.transform.position, Vector2.right * hit.distance, Color.red);
        if (hit.transform.gameObject.tag != "Player")
        {
            Debug.Log("Enemy Detected");
            Debug.Log("Hit something: " + hit.collider.name);
            path = null;
            //Debug.DrawRay(hit.collider.transform.position, -Vector2.up * hit.distance * new Vector2(aiDirection, 0f), Color.red);
        }
        else
        {
            Debug.Log("NO Enemy Detected");
            //Debug.Log("Hit something: " + hit.collider.name);
            //Debug.DrawRay(hit.collider.transform.position, -Vector2.up * hit.distance * new Vector2(aiDirection, 0f), Color.green);
        }

        Vector2 lookDir = (Vector2)targetObj.transform.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
            
        
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
