using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] float rayObjectDistance;

    public LayerMask LayerMask;
    public Transform target;
    public GameObject rayObject;

    public bool hasLineOfSight = false;
    public float speed = 100f;
    public float nextWaypointDistance = 5f;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            Move();


    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }



    // FixedUpdate is called once every few frames
    void FixedUpdate()
    {
        
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

        if (force.x >= 0.01f)
        {
            enemyFlip.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            enemyFlip.localScale = new Vector3(1f, 1f, 1f);
        }
    }


     void Move()
    {
        Vector2 targetPos = target.position;
        Vector2 Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D hit = Physics2D.Raycast(rayObject.transform.position, Direction);

        
        if (hit.collider != null)
        {
            //Debug.DrawRay(rayObject.transform.position, Vector2.up * hit.distance, Color.red);
            if (hit.transform.gameObject.tag == "Player")
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
                hasLineOfSight = true;
                Debug.Log("Player Detected");
            }
            else
            {
                Debug.Log("NO Player Detected");
                hasLineOfSight = false;
                path = null;
                return;

            }
        }
        else
        {
            Debug.Log("NO Player Detected");
            hasLineOfSight=false;
            path = null;
            return;

        }

        

        //Vector2 lookDir = (Vector2)target.gameObject.transform.position - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;

    }
}
