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

    [SerializeField]
    private int check = 0;
    //public Item[] itemsToPickup;

    public void Awake()
    {
        item1 = null;
        item2 = null;

        //shield.SetActive(false);
        //bomb.SetActive(false);
        //bow.SetActive(false);
        //hookshot.SetActive(false);
        //sword.SetActive(false);
    }
    private void Start()
    {
        shield.SetActive(false);
        bomb.SetActive(false);
        bow.SetActive(false);
        hookshot.SetActive(false);
        sword.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item" && Input.GetButton("Fire1_P1"))
        {
            if(slot1 != null)
            {
                slot1.SetActive(false);
            }
            
            if(other.name == "Shield_Item")
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
            
            item1 = other.GetComponent<Item>();
        }
        if (other.tag == "Item" && Input.GetButton("Fire2_P1"))
        {


            item2 = other.GetComponent<Item>();
        }



    }

    IEnumerator ItemSetter(string item)
    {
        check++;
        if(item == "Bomb")
        {

        }



        yield return null;
        StopCoroutine(ItemSetter(item));
    }
    



}
