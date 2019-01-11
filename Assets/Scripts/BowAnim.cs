using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnim : MonoBehaviour
{

    Animator anim;
    public string Fire = "Fire1_P1";
    public float firingCharge;
    public float firingCooldown;
    public float fireChargeCount;

    public bool aiming;
    public bool arrowReady;
    public bool isFiring;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        arrowReady = false;
        isFiring = false;
        aiming = false;

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();   
    }

     // Whenever we shoot this function is run.
    void Shoot()
    {

        if (Input.GetButton(Fire) && BowFireScript.canFire)
        {
            firingCharge += Time.deltaTime;
            aiming = true;

        } 
        else if (Input.GetButtonUp(Fire) && firingCharge < fireChargeCount)
        {
            firingCharge = 0;
            aiming = false;
        }

        if (firingCharge >= fireChargeCount)
        {
            arrowReady = true;
        } 
            else 
        {
            arrowReady = false;
        }

        if (Input.GetButtonUp(Fire) && BowFireScript.canFire && arrowReady)
        {

            isFiring = true;

            firingCharge = 0f;
            aiming = false;

        }
        if (aiming)
        {
            anim.SetBool("Aiming", true);
        }
        else
        {
            anim.SetBool("Aiming", false);
        }

    }

}
