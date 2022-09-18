using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int colorIndex = 0;
    public List<Color> colors;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colors[colorIndex];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
