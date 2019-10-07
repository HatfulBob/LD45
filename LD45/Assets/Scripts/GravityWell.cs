using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    public float attractionRadius = 50f;

    private readonly float G = 6.67408e-6f;
    private Rigidbody rigidBody;
    private MassTracker massTracker;

    public GameObject soundEffect;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.mass = 10000000;
        massTracker = GameObject.FindObjectOfType<MassTracker>();
    }

    void OnCollisionEnter(Collision col)
    {
        Instantiate(soundEffect, col.transform.position, Quaternion.identity);
        //get the other object, get its mass
        float mass = col.gameObject.GetComponent<Rigidbody>().mass;
        //eject between 5-20% of the mass in a random direction
        float ejectionAmmount = Random.Range(0.05f, 0.2f) * mass;
        //TODO eject the remaining mass outwards in a random direction

        float retainedAmmount = mass - ejectionAmmount;
        massTracker.massTracked += retainedAmmount;

        //add the 95-80% of the mass to the current mass
        rigidBody.mass = rigidBody.mass + retainedAmmount;
        //delete the other object
        Destroy(col.gameObject);
    }

    void FixedUpdate()
    {
        Collider[] inRange = Physics.OverlapSphere(this.transform.position, attractionRadius);
        for(int i = 0; i < inRange.Length; i++)
        {
            if (inRange[i].gameObject.name != this.gameObject.name && inRange[i].gameObject.name != "Sun(Clone)")
            {
                
                Vector3 direction = this.transform.position - inRange[i].transform.position;
                Rigidbody rigidBody = this.gameObject.GetComponent<Rigidbody>();
                float force = (float)calculateForce(rigidBody, inRange[i].gameObject.GetComponent<Rigidbody>());
                inRange[i].gameObject.GetComponent<Rigidbody>().AddForce(force * direction);
            }
        }
    }

    double calculateForce(Rigidbody obj1, Rigidbody obj2)
    {
        float distance = Vector3.Distance(obj1.transform.position, obj2.transform.position) * 10;
        return obj1.mass * obj2.mass * G / System.Math.Pow(distance, 2);
    }
}
