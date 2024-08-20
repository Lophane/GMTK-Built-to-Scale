using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public Transform player;
    //public GameObject initialPrefab;
    public GameObject[] tilemapPrefabs;
    public float spawnHeight = 10f;
    public float spawnDistanceAhead = 20f;

    private float nextSpawnY;

    void Start()
    {

        //Instantiate(initialPrefab, new Vector3(0, player.position.y, player.position.z+1), Quaternion.identity);

        nextSpawnY = player.position.y + 10f;

        while (nextSpawnY < player.position.y + spawnDistanceAhead)
        {
            SpawnNextTilemap();
        }
    }

    void Update()
    {
        if (player.position.y + spawnDistanceAhead > nextSpawnY)
        {
            SpawnNextTilemap();
        }
    }

    void SpawnNextTilemap()
    {
        int index = Random.Range(0, tilemapPrefabs.Length);
        Vector3 spawnPosition = new Vector3(3, nextSpawnY, player.position.z+1);
        Instantiate(tilemapPrefabs[index], spawnPosition, Quaternion.identity);
        nextSpawnY += spawnHeight;
    }
}