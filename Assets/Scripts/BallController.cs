using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour {

    public Vector3 EndPosition;
    public Transform cameraPos;

    private float notFloatingTime = 1f;
    private float movingTime = 0f;
    private float startTime;

    private Vector3 minRange = new Vector3(-8f, 1f, 0f);
    private Vector3 maxRange = new Vector3(8f, 4f, 17f);

    void Start () {
        transform.DOMove(EndPosition, 0.5f);
        startTime = Time.time;
    }
	
    void Update ()
    {
        if (notFloatingTime > 0)
            notFloatingTime -= Time.deltaTime;
        else
        {
            float localTime = Time.time - startTime;
            transform.Translate(new Vector3(0f, 0.05f * Mathf.Sin(localTime), 0f));
        }

        if (movingTime <= 0f)
        {
            Vector3 newPos = new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
            movingTime = Random.Range(0.5f, 1.5f);
            transform.DOMove(newPos, movingTime);
        }
        else
        {
            movingTime -= Time.deltaTime;
        }

        transform.LookAt(cameraPos);
    }
}
