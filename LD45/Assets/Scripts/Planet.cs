using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
    public Material[] textures;
    private MeshRenderer myMesh;
    private Material texture;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();

        //pick random texture
        texture = textures[Random.Range(0, textures.Length)];

        //apply texture
        myMesh.material = texture;
        myMesh.material.color = RandomColor();
    }

    private Color RandomColor()
    {
        return Color.HSVToRGB(Random.Range(0, .9f), 1, Random.Range(0.6f, 1));
    }
}
