using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    float xLimit = 800f;
    float yLimit = 20f;
    float zLimit = 800f;
    public int spawnAmmount = 100000;
    public float spawnRadius = 200f;

    public GameObject obj;
    bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            Debug.Log(i);
           do
           {
                float radius = Random.Range(0, spawnRadius);
                Vector3 pos = RandomCircle(transform.position, radius);
                Debug.Log("test");
                isOccupied = Physics.CheckSphere(pos, 1f);
                Debug.Log(isOccupied + " i");
                if (!isOccupied)
                {
                    Debug.Log("Placed");
                    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, transform.position);
                    GameObject newObj = Instantiate(obj, pos, rot);
                    newObj.transform.parent = transform;
                }
            } while (isOccupied);
        }
    }

    Vector3 RandomCircle(Vector3 centre, float radius)
    {
        float ang = Random.Range(0f, 360f);
        Vector3 pos;
        pos.x = centre.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.z = centre.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = centre.y + Random.Range(-20f, 20f);
        return pos;
    }
}
