using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triforce : MonoBehaviour {

    public GameObject TriPowG;
    public GameObject TriPowB;
    public GameObject TriPowR;
    public GameObject TriWisG;
    public GameObject TriWisBlack;
    public GameObject TriWisBlue;
    public GameObject TriCourG;
    public GameObject TriCourB;
    public GameObject TriCourGreen;
    public GameObject EOGTimer;

    public Text rupeeDisplay;
    public Text completeCountdown;
    public float coolDown = 60f;
    public int rupeeCount;

    public bool power = false;
    public bool wisdom = false;
    public bool courage = false;


    // Use this for initialization
    void Start()
    {
        TriPowB.gameObject.SetActive(true);
        TriWisBlack.gameObject.SetActive(true);
        TriCourB.gameObject.SetActive(true);
        TriPowG.gameObject.SetActive(false);
        TriWisG.gameObject.SetActive(false);
        TriCourG.gameObject.SetActive(false);
        TriPowR.gameObject.SetActive(false);
        TriWisBlue.gameObject.SetActive(false);
        TriCourGreen.gameObject.SetActive(false);

        EOGTimer.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        ShowRupee();
        TriforceDisplay();

    }

    public void TriforceDisplay()
    {
        if (power == true && wisdom == true && courage == true)
        {
            TriPowG.gameObject.SetActive(true);
            TriWisG.gameObject.SetActive(true);
            TriCourG.gameObject.SetActive(true);
            TriPowB.gameObject.SetActive(false);
            TriWisBlack.gameObject.SetActive(false);
            TriCourB.gameObject.SetActive(false);
            TriPowR.gameObject.SetActive(false);
            TriWisBlue.gameObject.SetActive(false);
            TriCourGreen.gameObject.SetActive(false);

            coolDown -= Time.deltaTime;
            EOGTimer.SetActive(true);
            completeCountdown.text = ("Triforce Complete Game Over in: " + (int)coolDown);
        }
        else
        {
            coolDown = 60f;
            EOGTimer.SetActive(false);
            if (power == true)
            {
                TriPowB.gameObject.SetActive(false);
                TriPowR.gameObject.SetActive(true);
            }
            else if (power != true)
            {
                TriPowB.gameObject.SetActive(true);
                TriPowR.gameObject.SetActive(false);
                TriPowG.gameObject.SetActive(false);
            }

            if (wisdom == true)
            {
                TriWisBlack.gameObject.SetActive(false);
                TriWisBlue.gameObject.SetActive(true);
            }
            else if (wisdom != true)
            {
                TriWisBlack.gameObject.SetActive(true);
                TriWisBlue.gameObject.SetActive(false);
                TriWisG.gameObject.SetActive(false);
            }
            if (courage == true)
            {
                TriCourB.gameObject.SetActive(false);
                TriCourGreen.gameObject.SetActive(true);
            }
            if (courage != true)
            {
                TriCourB.gameObject.SetActive(true);
                TriCourGreen.gameObject.SetActive(false);
                TriCourG.gameObject.SetActive(false);
            }
        }
    }

    public void ShowRupee ()
    {
        rupeeDisplay.text = ("" + rupeeCount);
        if (rupeeCount >= 50)
        {
            courage = true;
        }
    }
}
