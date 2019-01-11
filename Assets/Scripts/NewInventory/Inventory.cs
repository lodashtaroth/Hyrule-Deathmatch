using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item item1;
    public Item item2;

    [SerializeField]
    private int check = 0;
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

            for (int i = 0; i < itemsToPickup.Length; i++)
            {
                switch (check)
                {
                    case 0:
                        check = 0;

                        check++;
                        break;
                    case 1:
                        check = 1;

                        check++;
                        break;
                    case 2:
                        check = 2;

                        check++;
                        break;
                    case 3:
                        check = 3;
                        check = 0;
                        break;
                }

            }


        }



    }
}
