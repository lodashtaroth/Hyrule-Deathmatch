using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Static instance of the Game Manager,
	// can be access from anywhere
	public static MenuManager instance = null;
	public GameObject[] homeObjects;
	public GameObject[] modeObjects;
    public GameObject[] playersTDObjects;
	public GameObject[] playersFPSObjects;
    public GameObject[] optObjects;


	// Use this for initialization
	void Start () {
		
		homeObjects = GameObject.FindGameObjectsWithTag("Home");
		modeObjects = GameObject.FindGameObjectsWithTag("ModeSelect");
        playersTDObjects = GameObject.FindGameObjectsWithTag("PlayerSelect");
		playersFPSObjects = GameObject.FindGameObjectsWithTag("PlayerSelectFPS");
        optObjects = GameObject.FindGameObjectsWithTag("Options");
		showHome ();
		hideMode ();
        hidePlayersTD();
		hidePlayersFPS ();
        hideOptions ();

	}

	//shows objects with Home tag
	public void showHome(){
        hidePlayersTD();
		hidePlayersFPS ();
		hideMode ();
		hideOptions ();
		foreach(GameObject g in homeObjects){
			g.SetActive(true);
		}
	}
		//hides objects with Home tag
	public void hideHome(){
		foreach(GameObject g in homeObjects){
			g.SetActive(false);
		}
	}
	//shows objects with Home tag
	public void showMode(){
		hideHome ();
		hidePlayersTD();
		hidePlayersFPS ();
		hideOptions ();
		foreach(GameObject g in modeObjects){
			g.SetActive(true);
		}
	}
	//hides objects with Home tag
	public void hideMode(){
		foreach(GameObject g in modeObjects){
			g.SetActive(false);
		}
	}
    //shows objects Players tag
    public void showPlayersTD(){
        hideHome();
		hideMode ();
		hidePlayersFPS ();
        hideOptions();
        foreach (GameObject g in playersTDObjects)
        {
            g.SetActive(true);
        }
    }
    //hides objects with Players tag
    public void hidePlayersTD(){
        foreach (GameObject g in playersTDObjects)
        {
            g.SetActive(false);
        }
    }
	//shows objects Players tag
	public void showPlayersFPS(){
		hideHome();
		hideMode ();
		hideOptions();
		hidePlayersTD ();
		foreach (GameObject g in playersFPSObjects)
		{
			g.SetActive(true);
		}
	}
	//hides objects with Players tag
	public void hidePlayersFPS(){
		foreach (GameObject g in playersFPSObjects)
		{
			g.SetActive(false);
		}
	}
    //shows objects with Options tag
    public void showOptions(){
		hideMode ();
        hidePlayersTD();
		hidePlayersFPS ();
		hideHome ();
		foreach(GameObject g in optObjects){
			g.SetActive(true);
		}
	}
	//hides objects with Options tag
	public void hideOptions(){
		foreach(GameObject g in optObjects){
			g.SetActive(false);
		}
	}
		
}