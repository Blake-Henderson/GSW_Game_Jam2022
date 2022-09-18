using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //thanks Brackeys
    public Camera cam;
    public Transform rangedFirepoint;
    public Transform meleeFirepoint;
    public GameObject rangedPrefab;
    public GameObject meleePrefab;
    public GameObject AOEPrefab;
    public Rigidbody2D rb;
    public SpellDataManager spellDataManager;

    public float fireRate = 1;

    private float timer = 1;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && timer >= fireRate)
        {
            Spell spell = spellDataManager.spells[spellDataManager.selectedSpell];
            if (spell.attack == Spell.attackType.Ranged)
            {
                GameObject temp = Instantiate(rangedPrefab,rangedFirepoint.position, rangedFirepoint.rotation);
                temp.GetComponent<SpellProjectile>().data = spell;
            }
            else if(spell.attack == Spell.attackType.Melee && spell.effects != Spell.specialEffects.AOE){
                GameObject temp = Instantiate(meleePrefab, meleeFirepoint.position, meleeFirepoint.rotation);
                temp.GetComponent<MeleeSpell>().data = spell;
            }
            else
            {
                GameObject temp = Instantiate(AOEPrefab, transform.position, Quaternion.identity);
                temp.GetComponent<AOE>().data = spell;
            }
            timer = 0;
        }
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg -90.0f;
        rb.rotation = angle;
    }

}
