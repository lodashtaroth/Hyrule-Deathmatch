using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item item1;
    public Item item2;

    public Item[] itemsToPickup;

    public void Awake()
    {
        item1 = null;
        item2 = null;
    }

    void Start()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item" && Input.GetButton("Fire1_P1"))
        {

            item1 = other.GetComponent<Item>();


        }
        if (other.tag == "Item" && Input.GetButton("Fire2_P1"))
        {

            item2 = other.GetComponent<Item>();


        }
    }
}
