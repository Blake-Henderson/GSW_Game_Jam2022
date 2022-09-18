using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDataManager : MonoBehaviour
{
    public int selectedSpell = 0;
    /// <summary>
    /// The list of spells the player has
    /// </summary>
    public List<Spell> spells;


    void Start()
    {
        SelectSpell();
    }

    void Update()
    {
        int previousSelectedSpell = selectedSpell;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedSpell >= 2)
                selectedSpell = 0;
            else
            selectedSpell++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedSpell <= 0)
                selectedSpell = 2;
            else
                selectedSpell--;
        }
        if (previousSelectedSpell != selectedSpell)
        {
            SelectSpell();
        }
    }

    void SelectSpell()
    {
        int i = 0;
        foreach (Transform spell in transform)
        {
            if (i == selectedSpell)
                spell.gameObject.SetActive(true);
            else
                spell.gameObject.SetActive(false);
            i++;
        }
    }

}
