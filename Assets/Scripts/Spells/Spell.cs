using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Spell", menuName ="spell")]
public class Spell : ScriptableObject
{
    /// <summary>
    /// The elemet of the damage
    /// </summary>
    public enum damageType
    {
        Ather,
        Water,
        Fire,
        Earth,
        Wind
    };
    /// <summary>
    /// If the attack is melee or ranged
    /// </summary>
    public enum attackType
    {
        Melee,
        Ranged
    };
    /// <summary>
    /// The special effects a spell can have
    /// </summary>
    public enum specialEffects
    {
        Null,
        Stun,
        AOE,
        DOT,
        Slow,
        LifeSteal
    };
    /// <summary>
    /// The damage type of this spell
    /// </summary>
    public damageType type;
    /// <summary>
    /// If this specific attack is melee or ranged
    /// </summary>
    public attackType attack;
    /// <summary>
    /// What effect(s) this spell has
    /// </summary>
    public specialEffects effects;    

    public int getDamage(GameObject gameObject)
    {
        int damage = 1;
        //the switch for effects AOE->DOT->Stun->Slow->Life steal
        switch (type)
        {
            case Spell.damageType.Ather:
                if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Ather)
                    damage = 2;
                else
                    damage = 1;
                break;
            case Spell.damageType.Water:
                if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Fire)
                    damage = 2;
                else if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Earth)
                    damage = 0;
                else
                    damage = 1;
                break;
            case Spell.damageType.Fire:
                if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Wind)
                    damage = 2;
                else if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Water)
                    damage = 0;
                else
                    damage = 1;
                break;
            case Spell.damageType.Earth:
                if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Water)
                    damage = 2;
                else if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Wind)
                    damage = 0;
                else
                    damage = 1;
                break;
            case Spell.damageType.Wind:
                if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Earth)
                    damage = 2;
                else if (gameObject.GetComponent<EnemyHealth>().type == EnemyHealth.element.Fire)
                    damage = 0;
                else
                    damage = 1;
                break;
        }
        return damage;
        //attach relvent scripts to enemy
    }
}
