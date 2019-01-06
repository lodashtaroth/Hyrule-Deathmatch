using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPGameOver : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject gameOverCams;
	public GameObject mainHud;
	public GameObject deathCams;
	public HUDScript p1hudScript;
	public HUDScript p2hudScript;
    public HUDScript p3hudScript;
    public HUDScript p4hudScript;
    public bool p1isDead;
	public bool p2isDead;
    public bool p3isDead;
    public bool p4isDead;
    public int p1hearts;
	public int p2hearts;
    public int p3hearts;
    public int p4hearts;


    // Use this for initialization
    void Start () {

		gameOverCams.gameObject.SetActive (false);

		p1hearts = p1hudScript.heart;
		p2hearts = p2hudScript.heart;
        p3hearts = p3hudScript.heart;
        p4hearts = p4hudScript.heart;

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
        if (p3.activeInHierarchy == false)
        {
            p3isDead = true;
        }
        else
        {
            p3isDead = false;
        }
        if (p4.activeInHierarchy == false)
        {
            p4isDead = true;
        }
        else
        {
            p4isDead = false;
        }

        //to choose who wins
        if (p2hearts <=0 && p3hearts <= 0 && p4hearts <= 0)
        {
            GameEnd();
            p1Wins();
            ShowGameOverCams();
        }
        if (p1hearts <= 0 && p3hearts <= 0 && p4hearts <= 0) {
			GameEnd ();
			p2Wins ();
			ShowGameOverCams ();
		} 
        if (p1hearts <= 0 && p2hearts <= 0 && p4hearts <= 0){
			GameEnd ();
			p3Wins ();
			ShowGameOverCams ();
		}
        if (p1hearts <= 0 && p2hearts <= 0 && p3hearts <= 0)
        {
            GameEnd();
            p4Wins();
            ShowGameOverCams();
        }


        p1hearts = p1hudScript.heart;
		p2hearts = p2hudScript.heart;
        p3hearts = p3hudScript.heart;
        p4hearts = p4hudScript.heart;

    }

	//for making sure both player characters become inactive
	void GameEnd (){
		p1.gameObject.SetActive (false);
		p2.gameObject.SetActive (false);
        p3.gameObject.SetActive(false);
        p4.gameObject.SetActive(false);
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
    void p3Wins()
    {
        print("Player 3 Wins!!");

        //add functions here
    }
    void p4Wins()
    {
        print("Player 4 Wins!!");

        //add functions here
    }

}
