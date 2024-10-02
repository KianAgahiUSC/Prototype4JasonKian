using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float minX, maxX, minY, maxY, timeBetweenSpawn;
    private float spawnTime;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            SpawnEnemy(enemy);
            spawnTime = Time.time + player.playerPower;
        }
        //Debug.Log(player.playerPower);
    }


    void SpawnEnemy(GameObject enemy)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(enemy, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
