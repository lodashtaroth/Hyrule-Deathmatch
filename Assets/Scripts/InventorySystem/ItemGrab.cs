using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemGrab : MonoBehaviour {


    public GameObject myWeapon; //weapon Im currently holding
    public GameObject weaponOnGround; //weapon that is currently on the ground

    public bool pickupLeft = false;
    public bool pickupRight = false;

    // Use this for initialization
    void Start () {
        myWeapon.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P))
        {
            myWeapon.SetActive(false);
        }

        if (Input.GetButton("Fire1_P1"))
        {
            pickupLeft = true;
        }
        else
        {
            pickupLeft = false;
        }
        if (Input.GetButton("Fire2_P1"))
        {
            pickupRight = true;
        }
        else
        {
            pickupRight = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "P1" /*&& pickupLeft == true && pickupRight == true*/)
        {
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
        if (other.gameObject.tag == "P2")
        {
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
        if (other.gameObject.tag == "P3")
        {
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
        if (other.gameObject.tag == "P4")
        {
            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);
        }
    }
}
