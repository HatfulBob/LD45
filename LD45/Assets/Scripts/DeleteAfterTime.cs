using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    public int time;
    // Start is called before the first frame update
    public float timeWaiting;
    void Start()
    {
        timeWaiting = Time.deltaTime;
    }

    void Update()
    {
        if(timeWaiting < time)
        {
            timeWaiting += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
