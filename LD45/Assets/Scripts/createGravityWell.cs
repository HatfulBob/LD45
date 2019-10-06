using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createGravityWell : MonoBehaviour
{
    public GameObject gravityWell;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(gravityWell, Camera.main.WorldToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)), Quaternion.identity);
        }
    }
}
