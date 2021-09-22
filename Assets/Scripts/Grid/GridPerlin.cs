using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridPerlin : MonoBehaviour
{
    public GameObject cube;
    public int gridX;
    public int gridZ;
    public float gridSpacing;
    private float perlin;
    public float amount;
    public float perlinNoise;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }
    

    // Update is called once per frame
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                perlin = Mathf.PerlinNoise(x * amount,z * amount) ;
                Instantiate(cube, new Vector3(x * gridSpacing, perlin * perlinNoise,z * gridSpacing), Quaternion.identity);
            }
        }
    }
}
