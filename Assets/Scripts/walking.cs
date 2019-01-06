using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour {

	public string horizontalCtrl = "Horizontal_P1";
	public string verticalCtrl = "Vertical_P1";
	public string mouseXCtrl = "Mouse X_P1";
	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

        /*if (Input.GetButton(horizontalCtrl) || Input.GetButton(verticalCtrl))
		{
			anim.SetBool("Moving", true);
		}
		else
		{
			anim.SetBool("Moving", false);
		}*/

        //for forward animation
        if (Input.GetAxis(verticalCtrl) != 0)
        {
            anim.SetBool("forwardMoving", true);
        }
        else
        {
            anim.SetBool("forwardMoving", false);
        }
        //for strafe animation
        /*if (Input.GetAxis(horizontalCtrl) != 0)
        {
            anim.SetBool("sideMoving", true);
        }
        else
        {
            anim.SetBool("sideMoving", false);
        }*/

    }
}
