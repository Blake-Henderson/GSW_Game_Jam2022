using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarAdd : MonoBehaviour
{
    public List<GameObject> slots;
    public SpellDataManager spells;
    public void Update()
        {
            for(int i = 0; i<slots.Count; i++)
            {
                if(slots[i].GetComponent<Slot>().contents != null)
                {
                    Spell temp = slots[i].GetComponent<Slot>().contents.GetComponent<SpellHolder>().spell;
                    Debug.Log(i);
                    spells.spells[i]= temp;
                }
            }
        }
}
