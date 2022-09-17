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

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayObjectDistance, LayerMask);
        Debug.DrawRay(rayObject.transform.position, Vector2.right * hit.distance, Color.red);
        if (hit.collider != null)
        {
            Debug.Log("Enemy Detected");
            Debug.Log("Hit something: " + hit.collider.name);
            //Debug.DrawRay(hit.collider.transform.position, -Vector2.up * hit.distance * new Vector2(aiDirection, 0f), Color.red);
        }
        else
        {
            Debug.Log("NO Enemy Detected");
            //Debug.Log("Hit something: " + hit.collider.name);
            //Debug.DrawRay(hit.collider.transform.position, -Vector2.up * hit.distance * new Vector2(aiDirection, 0f), Color.green);
        }
    
            
            
        
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
