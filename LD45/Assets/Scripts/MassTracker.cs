using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassTracker : MonoBehaviour
{
    public double massTracked = 0d;
    public Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (massTracked > 0)
        {
            text.text = "Mass Collected: " + massTracked + "kg";
        }
    }
}
