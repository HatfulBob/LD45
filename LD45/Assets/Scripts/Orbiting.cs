using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public GameObject center;

    public float rotSpeed;
    public bool clockwiseRoation;

    float timer = 0;

    void Start()
    {
        int prob = Random.Range(0, 100);
        if (prob > 50)
        {
            clockwiseRoation = true;
        }
        else
        {
            clockwiseRoation = false;
        }

        center = GameObject.Find("star");
        float dist = Vector3.Distance(center.transform.position, transform.position);
        xSpread = dist;
        zSpread = dist;
        yOffset = transform.position.y;

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        Rotate();
    }

    void Rotate()
    {
        if (clockwiseRoation)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + center.transform.position;
        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + center.transform.position;
        }
    }

    public void IncrementSpeed()
    {
        xSpread += 0.5f;
        zSpread += 0.5f;
    }

    public void DecrementSpeed()
    {
        xSpread -= 0.5f;
        zSpread -= 0.5f;
    }
}
