using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour {

    public GameObject[] players;
    public Vector3[] positions;
    public GameObject[] weapons;
    public Vector3[] locations;
    public GameObject triforceWise;
    //  bool[] positionsTaken;

    public bool pos1taken = false;
    public bool pos2taken = false;
    public bool pos3taken = false;
    public bool pos4taken = false;
    public bool checkLoc = false;
    float x;
    float y;
    float z;


    // Use this for initialization
    void Start () {

        ChoosePlayer();
        ChooseWeapon();
        TriforcePos();
        if (checkLoc == true)
        {
            TriforcePos();
        }    
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChoosePlayer ()
    {

        int rnd = Random.Range(0, positions.Length);

        for(int i =0; i< players.Length; i++)
        {
            switch (rnd)
            {
                case 0:
                    rnd = 0;
                    players[i].transform.position = new Vector3(35f, 1.5f, 35f);
                    pos1taken = true;
                    rnd++;
                    break;
                case 1:
                    rnd = 1;
                    players[i].transform.position = new Vector3(-35f, 1.5f, 35f);
                    pos2taken = true;
                    rnd++;
                    break;
                case 2:
                    rnd = 2;
                    players[i].transform.position = new Vector3(35f, 1.5f, -35f);
                    pos3taken = true;
                     rnd++;
                    break;
                case 3:
                    rnd = 3;
                    players[i].transform.position = new Vector3(-35f, 1.5f, -35f);
                    pos4taken = true;
                    rnd = 0;
                    break;
            }
        }
    }

    public void ChooseWeapon()
    {

        int rnd = Random.Range(0, positions.Length);

        for (int i = 0; i < weapons.Length; i++)
        {
            switch (rnd)
            {
                case 0:
                    rnd = 0;
                    weapons[i].transform.position = new Vector3(-2f, 1f, -3f);
                    rnd++;
                    break;
                case 1:
                    rnd = 1;
                    weapons[i].transform.position = new Vector3(16.5f, 1f, 22.5f);
                    rnd++;
                    break;
                case 2:
                    rnd = 2;
                    weapons[i].transform.position = new Vector3(-15.5f, 1.5f, 25.8f);
                    rnd++;
                    break;
                case 3:
                    rnd = 3;
                    weapons[i].transform.position = new Vector3(-15f, 1.5f, -44.6f);
                    rnd++;
                    break;
                case 4:
                    rnd = 4;
                    weapons[i].transform.position = new Vector3(42f, 1.5f, -15f);
                    rnd = 0;
                    break;
            }
        }
    }

    public void TriforcePos ()
    {

        //Vector3 pos;

        x = Random.Range(-46f, 46f);
        y = 1f;
        z = Random.Range(-46f, 46f);

        triforceWise.transform.position = new Vector3(x, y, z);
        checkLoc = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Borders")
        {
            checkLoc = true;
        }
    }


}
