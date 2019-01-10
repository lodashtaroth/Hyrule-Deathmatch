using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	Animator anim;

	public AudioSource blockAudioSource;
	public string shieldBlk = "Fire2_P1";
	public bool block;
	public bool inputEnabled;
	private GameObject sword;
	public SwordScript atkScript;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		inputEnabled = true;
		block = false;

		//for enabling the collider to block
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;

	} 

	// Update is called once per frame
	void Update () {

		//For Blocking
		if (Input.GetButton (shieldBlk) && inputEnabled == true) {
			block = true;
			ShieldTrue ();
			print ("Blocking");    
		} else {
			block = false;
			ShieldFalse ();
		}

		//If the GameObject is not Blocking, send that the Boolean “Block” is false to the Animator. The Block animation does not play.
		if (block == false)
			anim.SetBool("Block", false);

		//The GameObject is Blocking, so send the Boolean as enabled to the Animator. The Block animation plays.
		if (block == true)
			anim.SetBool("Block", true);

		if (Time.timeScale == 0)
		{
			inputEnabled = false;
		}
		if (Time.timeScale == 1)
		{
			inputEnabled = true;
		}

	}

	//turns shield trigger collider on
	void ShieldTrue(){
		this.gameObject.GetComponent<BoxCollider> ().enabled = true;
	}
	//turns shield trigger collider off
	void ShieldFalse(){
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;

	}

}

