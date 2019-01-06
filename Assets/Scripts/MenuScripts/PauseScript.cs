using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	GameObject[] pauseObjects;
	public AudioSource pauseAudio;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();

	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		if(Input.GetButtonDown("Cancel")) {
			if(Time.timeScale == 1) {
				Time.timeScale = 0;
				showPaused();
				pauseAudio.Play ();
				//shows the cursor during pause
				Cursor.visible = true;
			} else if (Time.timeScale == 0) {
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
				Cursor.visible = false;
			}
		}

	}


	//Reloads the Level
	public void Reload(){
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}
				

	//Pauses the game
	public void Pause(){
		Time.timeScale = 0;
		showPaused ();
	}
	//Unpauses the game
	public void Unpause(){
		Time.timeScale = 1;
		hidePaused();
	}

	public void OpenScene(string sceneName) 
	{
		SceneManager.LoadScene (sceneName);
	}
}
