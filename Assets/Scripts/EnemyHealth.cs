using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth = 10f;
	public GameObject myDeathEffect;
	public AudioSource hitAudioSource;
	public AudioSource deathAudioSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyHealth <= 0) {
			Kill ();
		}

	}

	//Check if player enters/stays on the fire
	void OnTriggerEnter(Collider other)
	{
		//if player triggers fire object and health is greater than 0
		if (other.gameObject.name == "Sword" && enemyHealth > 0) {
			enemyHealth -= 2;  //reduce health
			hitAudioSource.Play (); //play enemy hit sound
		}

	}

	// Create our death effect and destroy ourself.
	protected void Kill() {
		Instantiate (myDeathEffect, transform.position, Quaternion.identity);
		deathAudioSource.Play();
		Destroy (gameObject);
	}
}
