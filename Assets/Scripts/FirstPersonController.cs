using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour {

	public float jumpHeight = 7f;
	public float movementSpeed = 10f;// how fast the player moves
	public float turningSpeed = 60f; //player turning speed
	public bool isGrounded;//to check if the player is touching the ground
	public bool pressedJump = false;//flag to keep track of whether a jump started
	public bool jump = false; //for jumping and flight functions
    public bool doomMove = false; // for doom style controls
	public bool goldeneyeMove = false; //for goldeneye style controls
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
	public bool inputEnabled = true; //for allowing input

    //public List[] inventory;


    public KeyCode Forward = KeyCode.UpArrow;


    // Use this for initialization
    void Start () {

        //get the rigid body component for later use
		rb = GetComponent<Rigidbody>();

        //get the player collider
        coll = GetComponent<Collider>();

		//hides the cursor during play
		Cursor.visible = false;

        jump = true;
        //Keycode kcForward = KeyCode.UpArrow;
        
    }

	// Update is called once per frame
	void Update () {


        if (inputEnabled == true) {
			
			// Handle player jumping
			JumpHandler();
	
		}
        if (doomMove == true && inputEnabled == true) {

			//Doom Style Mouse/Keyboard Controls
			DoomMove ();
          
        }
		if (goldeneyeMove == true && inputEnabled == true) {
			// For "Traditional" Goldeneye Controls
			GoldeEyeMove();
          
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


    void DoomMove (){
		float strafe = Input.GetAxis (horizontalCtrl) * movementSpeed;
		float translation = Input.GetAxis(verticalCtrl) * movementSpeed;
		float rotation = Input.GetAxis(mouseXCtrl) * turningSpeed;

		strafe *= Time.deltaTime;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(strafe, 0, 0);
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}

	void GoldeEyeMove() {
		float horizontal = Input.GetAxis ("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate (0, horizontal, 0);

		float vertical = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate (0, 0, vertical);


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


}