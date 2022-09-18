using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public bool interactable = false;

    private bool CraftingOpen = false;

    public GameObject SpellCraftUI;

    //interactable = false

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            interactable = false;
            Debug.Log("exit");
            SpellCraftUI.SetActive(false);
        }
    }

    public void Open()
    {
        SpellCraftUI.SetActive(true);
        //Time.timeScale = 0f;
        Debug.Log("Open");
        CraftingOpen = true;
    }
    public void Close()
    {
        SpellCraftUI.SetActive(false);
        //Time.timeScale = 1f;
        CraftingOpen = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& interactable)
        {
            Debug.Log("Interact");
            if (!CraftingOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
        else if(!interactable)
        {
            Close();
        }
    }
}
