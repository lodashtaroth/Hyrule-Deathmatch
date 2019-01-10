using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriforceManager : MonoBehaviour
{

    [Header("Rupees/Wisdom")]
    public HUDScript P1;
    public HUDScript P2;
    public HUDScript P3;
    public HUDScript P4;
    //[Range(0f, 10f)]
    public int p1Rupees;
    public int p2Rupees;
    public int p3Rupees;
    public int p4Rupees;

    // Start is called before the first frame update
    void Start()
    {

        p1Rupees = P1.rupees;
        p2Rupees = P2.rupees;
        p3Rupees = P3.rupees;
        p4Rupees = P4.rupees;

    }

    // Update is called once per frame
    void Update()
    {

        PlayerRupeeCount();

    }


    //check each players rupee count
    void PlayerRupeeCount ()
    {
        p1Rupees = P1.rupees;
        p2Rupees = P2.rupees;
        p3Rupees = P3.rupees;
        p4Rupees = P4.rupees;
    }
}
