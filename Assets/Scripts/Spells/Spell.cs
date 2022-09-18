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
}
