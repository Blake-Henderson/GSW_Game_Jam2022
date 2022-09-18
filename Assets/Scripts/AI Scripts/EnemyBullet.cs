using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Rigidbody2D rb;

    public float bulletForce = 20f;
    public int colorIndex = 0;
    public int damage;
    public List<Color> colors;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().color = colors[colorIndex];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if(collision.gameObject.tag == "Player")
        collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = bulletForce * gameObject.transform.right;
    }
}
