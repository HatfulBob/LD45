using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float rotationSpeed;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0, rotationSpeed, rotationSpeed/2));
    }
}
