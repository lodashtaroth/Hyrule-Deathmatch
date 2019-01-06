﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTester : MonoBehaviour {

	public PlayerHealth player;

	public void Heal (int health){
		player.Heal (health);
	}

	public void Hurt (int dmg){
		player.TakeDamage (dmg);
	}
}
