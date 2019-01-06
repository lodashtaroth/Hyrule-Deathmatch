using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
	public Text p1scoreText;
	public Text p2scoreText;
	//public GameObject p1ScoreObjectText;
	//public GameObject p2ScoreObjectText;
	public int p1score;
	public int p1deaths;
	public int p1rupees;
	public int p2score;
	public int p2deaths;
	public int p2rupees;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		p1scoreText.text = ("P1" + p1score);
	}
}
