using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGeneration : MonoBehaviour
{
    public GameObject targetPrefab;
    public Terrain terrain;
    public int numberOfTargets = 20;

    void Start()
    {
        GenerateTargets();
    }

    void GenerateTargets()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            Vector3 randomPosition = GetRandomTerrainPosition();
            GameObject target = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
            target.tag = "Target";
        }
    }

    Vector3 GetRandomTerrainPosition()
    {
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;

        float randomX = Random.Range(0f, terrainWidth);
        float randomZ = Random.Range(0f, terrainLength);

        float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ));

        return new Vector3(randomX, terrainHeight, randomZ);
    }
}
