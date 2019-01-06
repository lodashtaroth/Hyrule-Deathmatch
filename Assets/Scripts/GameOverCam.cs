using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCam : MonoBehaviour {

	public GameObject cam1;
	public GameObject cam2;
	public GameObject cam3;
	public float myTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		myTimer += Time.deltaTime;

		if (myTimer >= 5) {
			CamSwitch ();
			myTimer = 0f;
		}
	}

	void CamSwitch(){
		int randomNumber = Random.Range (1, 4);
		Debug.Log (randomNumber);

		if (randomNumber == 1) {
			cam1.gameObject.SetActive (true);
			cam2.gameObject.SetActive (false);
			cam3.gameObject.SetActive (false);
		} 
		if (randomNumber == 2) {
			cam1.gameObject.SetActive (false);
			cam2.gameObject.SetActive (true);
			cam3.gameObject.SetActive (false);
		} 
		if (randomNumber == 3) {
			cam1.gameObject.SetActive (false);
			cam2.gameObject.SetActive (false);
			cam3.gameObject.SetActive (true);
		} 

	}

}
