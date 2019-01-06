using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	public Slider healthBarSlider;  //reference for slider
	public Slider magicBarSlider; //reference for magic bar
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public int health;
    public int heart = 3;
    public int rupees;
    public Text rupeesText;
    public GameObject myDeathEffect;
	public AudioSource hitAudio;
	public AudioSource deathAudioSource;
    public AudioSource rupeeAudioSource;
    public GameObject[] GoObjects;
	public ShieldScript shieldScript;
	public bool isBlocking;


    void Start(){

        GoObjects = GameObject.FindGameObjectsWithTag("GameOver");
		hideGameOver ();
		health = 100;

		isBlocking = shieldScript.block;

        rupees = 0;
        rupeesText.text = ("" + (int)rupees);

    }

	// Update is called once per frame
	void Update () {
		
		if (heart == 0)
		{
			//GameOver ();
			Cursor.visible = true;
		}
		else if (health <=0 && heart >= 1)
		{
			Kill();
	
		}

		Hearts();

		//for interacting with shield script, so player can attack whilst blocking
		if (shieldScript.block == true) {
			isBlocking = true;
		} else {
			isBlocking = false;
		}

        rupeesText.text = ("" + (int)rupees);

    }

	//Check if player enters/stays on the fire
	void OnTriggerStay(Collider other){
		//if player triggers fire object and health is greater than 0
		if(other.gameObject.name=="Fire" && healthBarSlider.value>0){
			healthBarSlider.value -=.0100f;  //reduce health
			hitAudio.Play();
		}
		if(other.gameObject.name=="Enemy" && healthBarSlider.value>0){
			healthBarSlider.value -=.0100f;  //reduce health
			hitAudio.Play();
		}

    }

	//Check if player enters trigger
	void OnTriggerEnter(Collider other) {

		//if player triggers sword object and health is greater than 0
		if (other.gameObject.CompareTag ("Sword") && healthBarSlider.value > 0 && isBlocking ==false)
		{
			healthBarSlider.value -= .05000f;  //reduce health
			health -= 50;
			hitAudio.Play();
		}
        //if player triggers rupee object
        if (other.gameObject.CompareTag("GreenRupee"))
        {
            rupees += 1; // adds +1
            Destroy(other.gameObject); // destroys rupee
            rupeeAudioSource.Play(); // plays rupee pickup sound
        }
        //if player triggers rupee object
        if (other.gameObject.CompareTag("BlueRupee"))
        {
            rupees += 5; // adds +5
            Destroy(other.gameObject); //destroys rupee
            rupeeAudioSource.Play(); // plays rupee pickup sound
        }
        //if player triggers rupee object
        if (other.gameObject.CompareTag("RedRupee"))
        {
            rupees += 10; // adds +10
            Destroy(other.gameObject); //destroys rupee
            rupeeAudioSource.Play(); // plays rupee pickup sound
        }

    }

    //shows objects with GameOver tag
    public void showGameOver()
    {
        foreach (GameObject g in GoObjects)
        {
            g.SetActive(true);
        }
    }
    //hides objects with Home tag
    public void hideGameOver()
    {
        foreach (GameObject g in GoObjects)
        {
            g.SetActive(false);
        }
    }

    void GameOver() {
        showGameOver();
        Time.timeScale = 0;
    }

	//For respawning players
    void Respawn ()
    {
		print ("Respawning");

            health = 100;
            healthBarSlider.value = 1;

			PlayerPosition ();

    }
	//For showing active remaining lives
    public void Hearts ()
    {
        if (heart == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        if (heart == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        if (heart == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
		if (heart == 0)
		{
			heart1.SetActive(false);
			heart2.SetActive(false);
			heart3.SetActive(false);
		}
    }
	//For randomly respawning dead player
    public void PlayerPosition()
    {
		gameObject.SetActive (true);

        int spot = Random.Range(0, 4);

        if (spot == 0)
        {
            gameObject.transform.position = new Vector3(35f, 1.5f, 35f);
        }
        else if (spot == 1)
        {
            gameObject.transform.position = new Vector3(-35f, 1.5f, 35f);
        }
        else if (spot == 2)
        {
            gameObject.transform.position = new Vector3(35f, 1.5f, -35f);
        }
        else if (spot == 3)
        {
            gameObject.transform.position = new Vector3(-35f, 1.5f, -35f);
        }
    }

	// When we die play this function.
	void Kill() {
		Instantiate (myDeathEffect, transform.position, Quaternion.identity); // Create a death effect at our location.
		gameObject.SetActive (false); // Turn off this game object so that it doesn't render.
		deathAudioSource.Play(); //to play death audio
		heart--;
		Invoke ("Respawn", 5f); // In 3 seconds we will restart the game.
	}


	//create a function for zero hearts = out of game
    void Dead(){
        //turn off player and player hud
    }


}