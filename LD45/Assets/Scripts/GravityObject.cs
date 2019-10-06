using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    Rigidbody rigidBody;

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
}
