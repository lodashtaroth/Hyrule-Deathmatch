using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {
	// The time before we destroy this object.
	public float myDestroyTime = 0.3f;

	// We will destroy ourselves ones the time has passed.
	void Start () {
		Destroy (gameObject, myDestroyTime);	
	}
}
