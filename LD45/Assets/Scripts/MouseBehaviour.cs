using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    public GameObject gravityWell;
<<<<<<< HEAD

    private GameObject spawnedObj;
    void LeftClickBehaviour(Vector3 position)
    {
        spawnedObj = Instantiate(gravityWell, position, Quaternion.identity);
=======
    public Intro intro;
    void LeftClickBehaviour(Vector3 position)
    {
        if(intro.initialClick)
        Instantiate(gravityWell, position, Quaternion.identity);
>>>>>>> efba4fa2a8647b2e450c2908dfcc16dafb78492f
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

        float change = Input.GetAxis("Mouse ScrollWheel");
        if(change > 0)
        {
            Debug.Log("Scroll");
            spawnedObj.GetComponent<Orbiting>().IncrementSpeed();
        }else if(change < 0)
        {
            spawnedObj.GetComponent<Orbiting>().DecrementSpeed();
        }
    }
}
