using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Image[] hearts;
	public int healthPerheart = 4;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable() {
		Rules.MAX_PLAYER_HEALTH = hearts.Length * healthPerheart;
		PlayerHealth.OnHealthChanged += OnHealthChanged;
	}

	void OnDisable() {
		PlayerHealth.OnHealthChanged -= OnHealthChanged;
	}

	void OnHealthChanged(int health){
		int heart = health / healthPerheart; // default to lower bound 19 / 4 4 R 3
		int heartFill = health % healthPerheart; //return the remainder of the division

		if (health % healthPerheart == 0) {

			if (heart == hearts.Length) {// indicates full health
				hearts[heart-1].fillAmount =1;
				return;
			}

			if (heart > 0) {// indicates anything but zero health where there are whole hearts or empty hearts
				hearts [heart].fillAmount = 0;
				hearts [heart - 1].fillAmount = 1;
			} else {//indicates zero health
				hearts [heart].fillAmount = 0;
			}
			return;
		}

		hearts [heart].fillAmount = heartFill / (float)healthPerheart;
	}

}
