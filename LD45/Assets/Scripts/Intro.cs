using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public float spaceScale = -400f; //what size should the skybox blow up to be?
    public float scalingSpeed = 5f;
    public GameObject startingText;
    public GameObject skybox;
    public SpawnLevel levelSpawner;

    public bool initialClick = false;
    private float timeTillHintGiven;
    private float timeTillHintGivenMax = 5f;//hot many seconds of waiting before the game tells you to click;


    // Start is called before the first frame update
    void Start()
    {
        startingText.SetActive(false);
        timeTillHintGiven = timeTillHintGivenMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTillHintGiven > 0)
        {
            timeTillHintGiven -= Time.deltaTime;
        }
        else
        {
            if (!initialClick)
                startingText.SetActive(true);
        }

        if (Input.GetKeyDown("space") && !initialClick)
        {
            initialClick = true;
            levelSpawner.GenerateLevel();
        }

        if (initialClick)
        {
            if (startingText.activeSelf)
            {
                startingText.GetComponent<Text>().text = "Loading...";
            }
            //explode the universe!
            if (skybox.transform.localScale.z > spaceScale)
            {
                skybox.transform.localScale = new Vector3(skybox.transform.localScale.x + scalingSpeed, skybox.transform.localScale.y + scalingSpeed, skybox.transform.localScale.z + scalingSpeed);
            } else
            {

                startingText.SetActive(false);
            }
        }

    }

}
    /*
    private void OnMouseDown()
    {
        if (!initialClick)
        {
            initialClick = true;
            levelSpawner.GenerateLevel();
        }
    }
    
}*/