using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPGameOver : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
    public GameObject gameOverCams;
	public GameObject mainHud;
	public GameObject deathCams;
	public HUDScript p1hudScript;
	public HUDScript p2hudScript;
    public bool p1isDead;
	public bool p2isDead;
    public int p1hearts;
	public int p2hearts;


    // Use this for initialization
    void Start () {

		gameOverCams.gameObject.SetActive (false);

		p1hearts = p1hudScript.heart;
		p2hearts = p2hudScript.heart;

    }
	
	// Update is called once per frame
	void Update () {

        //to check is a player is dead
		if (p1.activeInHierarchy == false) {
			p1isDead = true;
		} else {
			p1isDead = false;
		}
		if (p2.activeInHierarchy == false) {
			p2isDead = true;
		} else {
			p2isDead = false;
		}


        //to choose who wins
        if (p2hearts <=0)
        {
            GameEnd();
            p1Wins();
            ShowGameOverCams();
        }
        if (p1hearts <= 0) {
			GameEnd ();
			p2Wins ();
			ShowGameOverCams ();
		} 
       
        p1hearts = p1hudScript.heart;
		p2hearts = p2hudScript.heart;

    }

	//for making sure both player characters become inactive
	void GameEnd (){
		p1.gameObject.SetActive (false);
		p2.gameObject.SetActive (false);
        mainHud.gameObject.SetActive (false);
		deathCams.gameObject.SetActive (false);
		Cursor.visible = true;
	}

	//Shows the game over cameras and scoreboard
	void ShowGameOverCams(){
		gameOverCams.gameObject.SetActive (true);
	}
	//Hides the game over cameras and scoreboard
	void HideGameOverCams(){
		gameOverCams.gameObject.SetActive (false);
	}

	void p1Wins(){
		print ("Player 1 Wins!!");

        //add functions here
	}
	void p2Wins(){
		print ("Player 2 Wins!!");

        //add functions here
    }
   

}
