using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Scriptable object items")]
    public Item item1;
    public Item item2;

    [Header("Reference to objects")]
    public GameObject shield;
    public GameObject bomb;
    public GameObject bow;
    public GameObject hookshot;
    public GameObject sword;

    [Header("Currently equipped items")]
    public GameObject slot1;
    public GameObject slot2;

    //[SerializeField]
    //private int check = 0;

    public void Awake()
    {
        item1 = null;
        item2 = null;
    }
    private void Start()
    {
        shield.SetActive(false);
        bomb.SetActive(false);
        bow.SetActive(false);
        hookshot.SetActive(false);
        sword.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item" && Input.GetKey(KeyCode.Q))
        {
            if (slot1 != null)
            {
                slot1.SetActive(false);
            }

            if (other.name == "Shield_Item")
            {
                shield.SetActive(true);
                slot1 = shield;
            }
            if (other.name == "Bomb_Item")
            {
                bomb.SetActive(true);
                slot1 = bomb;
            }
            if (other.name == "Bow_Item")
            {
                bow.SetActive(true);
                slot1 = bow;
            }
            if (other.name == "Hookshot")
            {
                hookshot.SetActive(true);
                slot1 = hookshot;
            }
            if (other.name == "Sword_Item")
            {
                sword.SetActive(true);
                slot1 = sword;
            }

            item1 = slot1.GetComponent<ItemPickup>().item;
        }
        if (other.tag == "Item" && Input.GetKey(KeyCode.E))
        {

            if (slot2 != null)
            {
                slot2.SetActive(false);
            }
            if (other.name == "Shield_Item")
            {
                shield.SetActive(true);
                slot2 = shield;
            }
            if (other.name == "Bomb_Item")
            {
                bomb.SetActive(true);
                slot2 = bomb;
            }
            if (other.name == "Bow_Item")
            {
                bow.SetActive(true);
                slot2 = bow;
            }
            if (other.name == "Hookshot")
            {
                hookshot.SetActive(true);
                slot2 = hookshot;
            }
            if (other.name == "Sword_Item")
            {
                sword.SetActive(true);
                slot2 = sword;
            }

            item2 = slot2.GetComponent<ItemPickup>().item;
        }
    }
}

