﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCotrl : MonoBehaviour {
    public GameObject targetPrefab;
    public GameObject ballPrefab;
    public GameObject iuc;

    public float MinSpawnDelay;
    public float MaxSpawnDelay;
    public int BallThreshold;

    private string[] textureNames = { "Man", "Mars", "Rob" };
    private float timeTillNextSpawns;
    
    void Start () {
        timeTillNextSpawns = MinSpawnDelay;
        //SpawnBall();
    }

    void SpawnTarget() {
        var enemy = Instantiate (targetPrefab);

        int i = Random.Range(0, 3);
        enemy.GetComponent<Renderer>().material.mainTexture = Resources.Load(textureNames[i]) as Texture;
        
        float pos_x = Random.Range(-8f, 8.0f);
        float pos_z = Random.Range(0.0f, 17.0f);
        enemy.transform.position = new Vector3(pos_x, 3.03f, pos_z);

        iuc.GetComponent<UiController>().targetCount++;
    }

    void SpawnBall()
    {
        var enemy = Instantiate(ballPrefab);

        float pos_x = Random.Range(-8f, 8.0f);
        float pos_y = Random.Range(1f, 4f);
        float pos_z = Random.Range(0.0f, 17.0f);
        var ballController = enemy.GetComponent<BallController>();
        ballController.EndPosition = new Vector3(pos_x, pos_y, pos_z);

        iuc.GetComponent<UiController>().targetCount++;
    }
    
    void Update () {
        timeTillNextSpawns -= Time.deltaTime;
        if (timeTillNextSpawns <= 0f)
        {
            if (iuc.GetComponent<UiController>().targetCount < BallThreshold)
                SpawnTarget();
            else
                SpawnBall();
            timeTillNextSpawns = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        }
    }
}
