using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDataManager : MonoBehaviour
{
    
    /// <summary>
    /// The list of spells the player has
    /// </summary>
    public List<Spell> spells;

    public int selectedSpell = 0;

    public int maxSize = 3;

    void Start()
    {
        selectedSpell = 0;
    }

    void Update()
    {
        int previousSelectedSpell = selectedSpell;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedSpell >= maxSize - 1)
                selectedSpell = 0;
            else
            selectedSpell++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedSpell <= 0)
                selectedSpell = maxSize - 1;
            else
                selectedSpell--;
        }
        
    }

    

}
