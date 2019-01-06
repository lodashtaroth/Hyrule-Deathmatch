using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathChecker : MonoBehaviour {

	public GameObject Player;
	public GameObject deathCam;
	public Text countDownText;
	public GameObject CDText;
	public float coolDown = 5f;
	public bool isDead;

	// Use this for initialization
	void Start () {

		CDText.SetActive (false);
		isDead = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Player.activeInHierarchy == false) {
			isDead = true;
			coolDown -= Time.deltaTime;
			CDText.SetActive (true);
            countDownText.text = ("Respawn" + (int)coolDown);
        }
        else
        {
			isDead = false;
			CDText.SetActive (false);
			coolDown = 5f;
		}
		if (isDead == true)
        {
			deathCam.gameObject.SetActive (true);
		}
        else
        {
			deathCam.gameObject.SetActive (false);
		}
			
	}
		

}
