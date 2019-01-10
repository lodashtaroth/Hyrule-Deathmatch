using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

	Animator anim;

    public AudioSource slashAudioSource;
	public AudioSource chargeAudioSource;
	public AudioSource releaseAudioSource;
    bool swordAttack1;
	bool swordAttack2;
	bool swordAttack3;
	bool chargeAttack;
	bool chargeRelease;
	public bool charged;
	public float chargeTimer = 0f;
	public GameObject chargeEffect;
    public string swordAtk = "Fire1_P1"; 
    public bool inputEnabled; // for disabling input
	public ShieldScript shieldScript;// reference to shield script
	public bool isBlocking; // bool for blocking


    // Use this for initialization
    void Start () {

		anim = GetComponent<Animator> ();
		swordAttack1 = false;
		swordAttack2 = false;
		inputEnabled = true;
		charged = false;

		isBlocking = shieldScript.block;

		//for enabling the collider to attack
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;

    } 
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown (swordAtk) && inputEnabled == true && isBlocking == false) {

			Attack();
			print ("Attacked");
			SwordTrue ();
			Invoke ("SwordFalse", 0.4f);
		} else {
			swordAttack1 = false;
			swordAttack2 = false;
			swordAttack3 = false;
		}
	    //For Charge attacks
		if (Input.GetButton (swordAtk) && inputEnabled == true && isBlocking == false) {
			chargeTimer += Time.deltaTime;
			chargeAttack = true;
			//Invoke ("Charged", 2f);
			//Instantiate (chargeEffect, transform.position, Quaternion.identity);
		} else {
			chargeAttack = false;
			charged = false;
			chargeTimer = 0f;
		}
		if (Input.GetButtonUp (swordAtk) && inputEnabled && isBlocking == false /*&& charged*/) {
			chargeRelease = true;
			SwordTrue ();
			//releaseAudioSource.Play ();
			Invoke ("SwordFalse", 0.7f);
		} else {
			chargeRelease = false;
		}
		if (chargeTimer >= 1.5f) {
			charged = true;
		} else {
			charged = false;
		}

		//If the GameObject is not Attacking, send that the Boolean “Attack” is false to the Animator. The Attack animation does not play.
		if (swordAttack1 == false) {
			anim.SetBool ("Attack1", false);
		}
		if (swordAttack2 == false) {
			anim.SetBool ("Attack2", false);
		}
		if (swordAttack3 == false) {
			anim.SetBool ("Attack3", false);
		}
		if (chargeAttack == false) {
			anim.SetBool ("ChargeAttack", false);
		}
		if (chargeRelease == false) {
			anim.SetBool ("ChargeRelease", false);
		}
		

		//The GameObject is Attacking, so send the Boolean as enabled to the Animator. The Attack animation plays.
		if (swordAttack1 == true) {
			anim.SetBool ("Attack1", true);
			slashAudioSource.Play();
		}
		if (swordAttack2 == true) {
			anim.SetBool ("Attack2", true);
			slashAudioSource.Play();
		}
		if (swordAttack3 == true) {
			anim.SetBool ("Attack3", true);
			slashAudioSource.Play();
		}
		if (chargeAttack == true) {
			anim.SetBool ("ChargeAttack", true);
		}
		if (chargeRelease == true) {
			anim.SetBool ("ChargeRelease", true);
		}


		//for interacting with shield script, so player can attack whilst blocking
		if (shieldScript.block == true) {
			isBlocking = true;
		} else {
			isBlocking = false;
		}
	    
		//so player cant attack whilst paused
        if (Time.timeScale == 0)
        {
            inputEnabled = false;
        }
        if (Time.timeScale == 1)
        {
            inputEnabled = true;
        }
        
    }

	//For random attack animations
	void Attack(){
		int randomNumber = Random.Range (1, 4);
		Debug.Log (randomNumber);
	
		if (randomNumber == 1) {
			swordAttack1 = true;
		} 
		if (randomNumber == 2) {
			swordAttack2 = true;
		} 
		if (randomNumber == 3) {
			swordAttack3 = true;
		} 

	}
		
		
	//turns swords trigger collider on
	void SwordTrue(){
		this.gameObject.GetComponent<BoxCollider> ().enabled = true;
	}
	//turns swords trigger collider off
	void SwordFalse(){
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;

	}
		
		
}

