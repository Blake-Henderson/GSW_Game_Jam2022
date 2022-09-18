using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
   private void OnTriggerEnter(Collider Player)
    {
        Debug.Log("Crafting");
    }
}
