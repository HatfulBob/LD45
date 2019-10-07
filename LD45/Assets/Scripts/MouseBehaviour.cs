using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    public GameObject gravityWell;
    void LeftClickBehaviour(Vector3 position)
    {
        Instantiate(gravityWell, position, Quaternion.identity);
    }

    void RightClickBehaviour(Vector3 position)
    {

    }

    Vector3 getMouseClickPosition()
    {
        Vector3 clickPos = -Vector3.one;
        Plane plane = new Plane(Vector3.up, 0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distanceToPlane;

        if(plane.Raycast (ray, out distanceToPlane))
        {
            clickPos = ray.GetPoint(distanceToPlane);
        }
        return clickPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClickBehaviour(getMouseClickPosition());
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightClickBehaviour(getMouseClickPosition());
        }


    }
}
