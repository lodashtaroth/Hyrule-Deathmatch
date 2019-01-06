using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopDownController : MonoBehaviour {

	public float jumpHeight = 7f;
	public float movementSpeed = 10f;// how fast the player moves
	public float turningSpeed = 60f; //player turning speed
	public bool isGrounded;//to check if the player is touching the ground
	public bool pressedJump = false;//flag to keep track of whether a jump started
	public bool jump = false; //for jumping and flight functions
	public bool walkHandler = false; // for doom style controls
	public bool location1taken = false;
	public bool location2taken = false;
	public bool location3taken = false;
	public bool location4taken = false;
	public string horizontalCtrl = "Horizontal_P1";
	public string verticalCtrl = "Vertical_P1";
	public string mouseXCtrl = "Mouse X_P1";
	public string jumpCtrl = "Jump_P1";
	public Rigidbody rb;//to keep our rigid body
	public Collider coll; //for colliding
	public AudioSource powerUpAudioSource; //powerup audiosource
	public AudioSource jumpAudioSource; //jump audiosource
	public AudioSource deathAudioSource; // death audiosource
	public AudioSource hitAudio;
	public bool inputEnabled = true; //for allowing input
	public GameObject myDeathEffect;
	//Animator anim;


	// Use this for initialization
	void Start () {

		PlayerPosition();
		//get the rigid body component for later use
		rb = GetComponent<Rigidbody>();

		//get the player collider
		coll = GetComponent<Collider>();

		//hides the cursor during play
		Cursor.visible = false;

		jump = true;

		//anim = GetComponent<Animator> ();


	}

	// Update is called once per frame
	void Update () {

		/* if (Input.GetButton(horizontalCtrl) || Input.GetButton(verticalCtrl))
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }*/


		if (inputEnabled == true) {

			// Handle player jumping
			JumpHandler();

		}
		if (walkHandler == true && inputEnabled == true)
		{

			//Platformer Style Mouse/Keyboard Controls
			WalkHandler();

		}


		//for playing jump audio
		if (Input.GetButtonDown (jumpCtrl) && isGrounded == true && inputEnabled == true) {
			print("Jump");
			//play sound
			jumpAudioSource.Play();
		}

		//For hiding cursor when clicking resume
		if (Time.timeScale == 1) {
			Cursor.visible = false;
		}

		if (Time.timeScale == 0)
		{
			inputEnabled = false;
		}
		if (Time.timeScale == 1)
		{
			inputEnabled = true;
		}

	}


	// Make the player walk according to user input
	void WalkHandler()
	{
		// Set x and z velocities to zero
		rb.velocity = new Vector3(0, rb.velocity.y, 0);

		// Distance ( speed = distance / time --> distance = speed * time)
		//float distance = movementSpeed * Time.deltaTime;

		// Input on x ("Horizontal")
		float hAxis = Input.GetAxis(horizontalCtrl);

		// Input on z ("Vertical")
		float vAxis = Input.GetAxis(verticalCtrl);

		// Movement vector
		//Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);

		// Current position
		//Vector3 currPosition = transform.position;

		// New position
		//Vector3 newPosition = currPosition + movement;

		Vector3 movement = new Vector3(hAxis, 0.0f, vAxis);
		transform.rotation = Quaternion.LookRotation(movement);

		transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

		// Move the rigid body
		//rb.MovePosition(newPosition);
	}
		


	// Check whether the player can jump and make it jump
	void JumpHandler() {
		// Jump axis
		float jAxis = Input.GetAxis(jumpCtrl);

		// Is grounded
		isGrounded = CheckGrounded();

		// Check if the player is pressing the jump key
		if (jAxis > 0f) {
			// Make sure we've not already jumped on this key press
			if(!pressedJump && isGrounded){
				// We are jumping on the current key press
				pressedJump = true;

				// Jumping vector
				Vector3 jumpVector = new Vector3(0f, jumpHeight, 0f);

				// Make the player jump by adding velocity
				rb.velocity = rb.velocity + jumpVector;
			}            
		} else {
			// Update flag so it can jump again if we press the jump key
			pressedJump = false;
		}
	}

	// Check if the object is grounded
	bool CheckGrounded() {
		// Object size in x
		float sizeX = coll.bounds.size.x;
		float sizeZ = coll.bounds.size.z;
		float sizeY = coll.bounds.size.y;

		// Position of the 4 bottom corners of the game object
		// We add 0.01 in Y so that there is some distance between the point and the floor
		Vector3 corner1 = transform.position + new Vector3(sizeX/2, -sizeY / 2 + 0.01f, sizeZ / 2);
		Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
		Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
		Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);

		// Send a short ray down the cube on all 4 corners to detect ground
		bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.08f);
		bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.08f);
		bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.08f);
		bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.08f);

		// If any corner is grounded, the object is grounded
		return (grounded1 || grounded2 || grounded3 || grounded4);
	}



	//For spawning players start positions
	public void PlayerPosition ()
	{
		int spot = Random.Range(0, 4);

		if (spot == 0 && location1taken == false)
		{
			transform.position = new Vector3(35f, 1.5f, 35f);
			location1taken = true;
		}
		else if (spot == 1 && location2taken == false)
		{
			transform.position = new Vector3(-35f, 1.5f, 35f);
			location2taken = true;
		}
		else if (spot == 2 && location3taken == false)
		{
			transform.position = new Vector3(35f, 1.5f, -35f);
			location3taken = true;
		}
		else if (spot == 3 && location4taken == false)
		{
			transform.position = new Vector3(-35f, 1.5f, -35f);
			location4taken = true;
		}
	}


}