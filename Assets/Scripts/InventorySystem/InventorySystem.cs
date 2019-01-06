using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventorySystem : MonoBehaviour {

    public ItemGrab itemGrab;

    public Image Item1;
    public Image Item2;
    public Image SlotGUIitem1;
    public Image SlotGUIitem2;
    public Text pickupText;
    public bool pickupLeft = false;
    public bool pickupRight = false;

    public string action = "Fire3_P1";

    public GameObject myWeaponL; //weapon Im currently holding in left
    //public GameObject myWeaponR; //weapon Im currently holding in right
    public GameObject weaponOnGround; //weapon that is currently on the ground

    public MasterItem[] Inventory = new MasterItem[2];


    private void Start()
    {
        SlotGUIitem1.gameObject.SetActive(false);
        SlotGUIitem2.gameObject.SetActive(false);

        myWeaponL.SetActive(false);
        //myWeaponR.SetActive(false);

        pickupLeft = itemGrab.pickupLeft;
        pickupRight = itemGrab.pickupRight;

    }
    private void Update()
    {
        DropItem();

        if (Input.GetButton("Fire1_P1"))
        {
            pickupLeft = true;
        } else {
            pickupLeft = false;
        }
        if (Input.GetButton("Fire2_P1"))
        {
            pickupRight = true;

        } else {

            pickupRight = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            if (Inventory[0] == null && Inventory[1] != other.GetComponent<MasterItem>()/* && pickupLeft == true*/)
            {
                Inventory[0] = other.GetComponent<MasterItem>();
                SlotGUIitem1.sprite = Inventory[0].ItemIcon;
                SlotGUIitem1.gameObject.SetActive(true);
                other.gameObject.SetActive(false);
            }
            else if (Inventory[1] == null && Inventory[0] != other.GetComponent<MasterItem>()/* && pickupRight == true*/)
            {
                Inventory[1] = other.GetComponent<MasterItem>();
                SlotGUIitem2.sprite = Inventory[1].ItemIcon;
                SlotGUIitem2.gameObject.SetActive(true);
                other.gameObject.SetActive(false);
            }
        }
        //BASICALLY REALLY CLOSELY FOLLOW THIS CODE AND USE SIMILAR METHOD FOR SHOWING IN PLAYERS HAND

        if (other.gameObject.tag == "P1") {

            /*if (Inventory[0].isActiveAndEnabled){ // do something along these lines, but check which hand and what slot
                myWeapon.SetActive(true);
            } else {
                myWeapon.SetActive(false);
            }
            if (Inventory[1].isActiveAndEnabled)
            {
                myWeapon.SetActive(true);
            } else {
                myWeapon.SetActive(false);
            }*/

            if (Inventory[0] == other.GetComponent<MasterItem>())
            { // do something along these lines, but check which hand and what slot
                myWeaponL.SetActive(true);
            }
            //else
            // {
            //    myWeaponL.SetActive(false);
            //}
            if (Inventory[0] != other.GetComponent<MasterItem>())
            { // do something along these lines, but check which hand and what slot
                myWeaponL.SetActive(false);
            }
            if (Inventory[1] == other.GetComponent<MasterItem>())
            {
                //myWeaponR.SetActive(true);
                myWeaponL.SetActive(true);
            }
            else
            {
                //myWeaponR.SetActive(false);
                myWeaponL.SetActive(true);
            }

        }
    }

    void DropItem()
    {
        /*if (Input.GetButton (Action) && Input.GetButtonDown ("Fire1")){ 
                Inventory[0].transform.position = this.gameObject.transform.position + gameObject.transform.forward *2;
                Inventory[0].gameObject.SetActive(true);
                Inventory[0] = null;
                SlotGUIitem1.gameObject.SetActive(false);
            }
		
		if (Input.GetButton (Action) && Input.GetButtonDown ("Fire2")){
		        Inventory[1].transform.position = this.gameObject.transform.position + gameObject.transform.forward * 2;
                Inventory[1].gameObject.SetActive(true);
                Inventory[1] = null;
                SlotGUIitem2.gameObject.SetActive(false);
			}*/

        if (Input.GetButtonDown(action) || Input.GetKeyDown(KeyCode.O))
        {
            Inventory[0].transform.position = this.gameObject.transform.position + gameObject.transform.forward *2;
            Inventory[0].gameObject.SetActive(true);
            Inventory[0] = null;
            SlotGUIitem1.gameObject.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Inventory[1].transform.position = this.gameObject.transform.position + gameObject.transform.forward * 2;
            Inventory[1].gameObject.SetActive(true);
            Inventory[1] = null;
            SlotGUIitem2.gameObject.SetActive(false);
        }
    }
     
}
