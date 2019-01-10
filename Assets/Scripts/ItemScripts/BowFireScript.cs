using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowFireScript : MonoBehaviour
{

    //Animator anim;

    public string Fire = "Fire1_P1";

    // A reference to the prefab we will spawn when we shoot.
    public GameObject myArrow;

    public bool inputEnabled;

    // Start is called before the first frame update
    void Start()
    {

        //anim = GetComponent<Animator>();
        inputEnabled = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown(Fire) && inputEnabled == true)
        {
            Shoot();
        }

    }


    // Whenever we shoot this function is run.
    void Shoot()
    {
        //NOTE Need to fire in the correct direction!!

        // Create an instance of the bullet object at our location with a default rotation.
        Instantiate(myArrow, transform.position, Quaternion.AngleAxis(90, Vector3.right));
    }

}
