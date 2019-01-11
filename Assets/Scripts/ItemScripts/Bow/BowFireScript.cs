using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowFireScript : MonoBehaviour
{

    //Animator anim;

    public string Fire = "Fire1_P1";
    public float firingCharge;
    public float firingCooldown;
    public float fireChargeCount;
    [Space]
    public bool arrowReady;
    public static bool canFire;
    public bool isFiring;
    public bool inputEnabled;
    [Space]

    public AudioSource aimingAudio;
    public AudioSource firingAudio;

    [Space]
    // A reference to the prefab we will spawn when we shoot.
    public GameObject myArrow;
    [Space]
    public FiringState currentState;


    public enum FiringState
    {
        IDLE,
        LOADING,
        ATTACKING,
        COOLDOWN
    }



    // Start is called before the first frame update
    void Start()
    {

        //anim = GetComponent<Animator>();
        arrowReady = false;
        canFire = false;
        isFiring = false;
        inputEnabled = true;
        currentState = FiringState.IDLE;

    }

    // Update is called once per frame
    void Update()
    {

        Shoot();


        if (isFiring)
        {
            currentState = FiringState.ATTACKING;
        }

        //StateMachine
        switch (currentState)
        {
            case (FiringState.IDLE):
                canFire = true;
                break;
            case (FiringState.LOADING):
                // audio here mebe?
                break;
            case (FiringState.ATTACKING):

                break;
            case (FiringState.COOLDOWN):
                canFire = false;
                break;

        }


    }



    // Whenever we shoot this function is run.
    void Shoot()
    {

        if (Input.GetButton(Fire) && canFire)
        {
            firingCharge += Time.deltaTime;
            currentState = FiringState.LOADING;
            //anim.SetBool("Aiming", true);
        } 
        else if (Input.GetButtonUp(Fire) && firingCharge < fireChargeCount)
        {
            firingCharge = 0;
            currentState = FiringState.IDLE;
            //anim.SetBool("Aiming", false);

        }
        //for aiming audio
        if (Input.GetButtonDown(Fire)) 
        {
            aimingAudio.Play();
        }

        if (firingCharge >= fireChargeCount)
        {
            arrowReady = true;
        } 
            else 
        {
            arrowReady = false;
        }

        if (Input.GetButtonUp(Fire) && canFire && arrowReady)
        {

            isFiring = true;

            // Create an instance of the bullet object at our location with a default rotation.
            //Instantiate(myArrow, transform.position, Quaternion.AngleAxis(90, Vector3.right));
            Instantiate(myArrow, transform.position, transform.rotation);

            firingCharge = 0f;

            firingAudio.Play(); // plays arrow show audio

            StartCoroutine(CoolDown());
        }

    }

    private IEnumerator CoolDown()
    {
        currentState = FiringState.COOLDOWN;

        isFiring = false;

        //wait abit
        yield return new WaitForSeconds(firingCooldown);

        currentState = FiringState.IDLE;

    }



}
