using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredSpawn : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float SpawnPeriod;

    private float timeTillSpawn = 0f;

	// Use this for initialization
	void Start () {
		
	}

    void SpawnEnemy()
    {
        var enemyObject = Instantiate(EnemyPrefab);
        var spawnBox = GetComponent<BoxCollider>();
        float x = spawnBox.center.x + spawnBox.size.x / 2f;
        float y = spawnBox.center.y + spawnBox.size.y / 2f;
        float z = spawnBox.center.z + spawnBox.size.z / 2f;
        enemyObject.transform.position = new Vector3(
            Random.Range(spawnBox.center.x - spawnBox.size.x / 2f, spawnBox.center.x + spawnBox.size.x / 2f),
            Random.Range(spawnBox.center.y - spawnBox.size.y / 2f, spawnBox.center.y + spawnBox.size.y / 2f),
            Random.Range(spawnBox.center.z - spawnBox.size.z / 2f, spawnBox.center.z + spawnBox.size.z / 2f));
    }
	
	// Update is called once per frame
	void Update () {
        if (timeTillSpawn <= 0f)
        {
            SpawnEnemy();
            timeTillSpawn = SpawnPeriod;
        }
        else
            timeTillSpawn -= Time.deltaTime;
	}
}
