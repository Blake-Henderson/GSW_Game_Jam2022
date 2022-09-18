using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompSlots : MonoBehaviour
{
    [SerializeField] private GameObject elementSlot;
    [SerializeField] private GameObject attackSlot;
    [SerializeField] private GameObject effectSlot; 
    public GameObject craftedSpell;
    public SpellHolder craftSpell;

    public Element element = null;
    public Range range = null;
    public SpecialEffects effect = null;
    
    private void Start()
    {
        craftSpell = craftedSpell.GetComponent<SpellHolder>();
        GetComponent<Slot>().contents = craftedSpell;
        GetComponent<Slot>().contents.GetComponent<DragAndDrop>().slot = gameObject.GetComponent<Slot>();
    }

    private void Update()
    {
        if (elementSlot.GetComponent<Slot>().contents != null)
        {
            element = elementSlot.GetComponent<Slot>().contents.GetComponent<Element>();
        }
        else if (elementSlot.GetComponent<Slot>().contents == null)
        {
            element = null;
        }

        if (attackSlot.GetComponent<Slot>().contents != null)
        {
            range = attackSlot.GetComponent<Slot>().contents.GetComponent<Range>();
        }
        else if (attackSlot.GetComponent<Slot>().contents == null)
        {
            range = null;
        }

        if (effectSlot.GetComponent<Slot>().contents != null)
        {
            effect = effectSlot.GetComponent<Slot>().contents.GetComponent<SpecialEffects>();
        }
        else if (effectSlot.GetComponent<Slot>().contents == null)
        {
            effect = null;
        }

        if (effectSlot.GetComponent<Slot>().contents != null && 
        attackSlot.GetComponent<Slot>().contents != null && 
        elementSlot.GetComponent<Slot>().contents != null &&
        craftSpell!=null)
        {
            craft();
        }

        
    }

    private void craft()
    {
        
        if (element != null && range != null)
        {
            craftSpell.spell = new Spell();
            if (effect == null)
            {
                craftSpell.spell.updateSpell((int)(element.element),(int)(range.range),(int)(SpecialEffects.specialEffects.Null));
            }
            else
            {
                craftSpell.spell.updateSpell((int)(element.element),(int)(range.range),(int)(effect.specialEffect));
            }


        }
    }

    
}
