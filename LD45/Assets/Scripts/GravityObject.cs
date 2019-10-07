using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    Rigidbody rigidBody;
    int planetID;
    public GameObject soundEffect;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = Random.Range(1f, 20f);
    }

    void AddMass(float mass)
    {
        rigidBody.mass = +mass;
    }

    float GetMass()
    {
        return rigidBody.mass;
    }

    public void SetID(int id)
    {
        planetID = id;
    }

    public int GetID()
    {
        return planetID;
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(soundEffect, collision.transform.position, Quaternion.identity);

        GravityObject collisionGravObj = collision.gameObject.GetComponent<GravityObject>();
        if(collisionGravObj.GetID() < GetID())
        {
            AddMass(collisionGravObj.GetMass());
            Destroy(collision.gameObject);
        }
    }
}
