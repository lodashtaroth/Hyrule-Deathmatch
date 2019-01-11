using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowScript : MonoBehaviour
{
    public float myArrowSpeed = 0.5f;
    public float myDeathTime = 3f;

    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        // We automatically destroy our arrow so that it doesn't remain in memory.
        Destroy(gameObject, myDeathTime);
    }

    void Update()
    {
        myRigidbody.AddForce(myRigidbody.transform.forward * myArrowSpeed * 10);
    }


    // We will simply move our arrow down at our given speed.
    void FixedUpdate()
    {
       // myRigidbody.MovePosition(transform.position + (Vector3.forward * myArrowSpeed * Time.deltaTime));

    }

    // This handles collisions with enemies.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
