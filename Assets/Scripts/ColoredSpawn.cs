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
        var spawnBox = GameObject.Find("SpawnBox").transform;
        float x = spawnBox.position.x;
        float y = spawnBox.position.y;
        float z = spawnBox.position.z;
        enemyObject.transform.position = new Vector3(
            Random.Range(x - spawnBox.localScale.x / 2f, x + spawnBox.localScale.x / 2f),
            Random.Range(y - spawnBox.localScale.y / 2f, y + spawnBox.localScale.y / 2f),
            Random.Range(z - spawnBox.localScale.z / 2f, z + spawnBox.localScale.z / 2f));
        
        int color = Random.Range(1, 4);
        Debug.Log(color);
        enemyObject.GetComponentInChildren<ColoredEnemyController>().SetColor(color);
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
