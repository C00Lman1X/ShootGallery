using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour {

    public Vector3 EndPosition;

    private float notFloatingTime = 1f;
    private float startTime;
    
    void Start () {
        transform.DOMove(EndPosition, 1);
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
    }
}
