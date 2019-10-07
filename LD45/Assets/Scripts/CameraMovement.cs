using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity;

    void Update()
    {
        var x = new Vector2(Input.GetAxis("Left"), Input.GetAxis("Right"));
        var y = new Vector2(Input.GetAxis("Up"), Input.GetAxis("Down"));

        transform.Rotate(x* sensitivity, y* sensitivity, 0);
    }
}
