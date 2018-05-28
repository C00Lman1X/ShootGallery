using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour {

    public Vector3 EndPosition;
    public Transform cameraPos;
    public float ShootInterval;
    public UiController ui;

    private float notFloatingTime = 1f;
    private float notShootedTime = 0f;
    private float movingTime = 0f;
    private float startTime;

    private Vector3 minRange = new Vector3(-8f, 1f, 0f);
    private Vector3 maxRange = new Vector3(8f, 4f, 17f);

    private ReactiveTarget reactiveTarget;

    void Start () {
        transform.DOMove(EndPosition, 0.5f);
        startTime = Time.time;

        ui = GameObject.Find("Canvas").GetComponent<UiController>();
        reactiveTarget = gameObject.GetComponent<ReactiveTarget>();
    }
	
    void Update ()
    {
        if (reactiveTarget.IsDead())
            return;


        if (notFloatingTime > 0)
            notFloatingTime -= Time.deltaTime;
        else
        {
            float localTime = Time.time - startTime;
            transform.Translate(new Vector3(0f, 0.05f * Mathf.Sin(localTime), 0f));
        }

        if (movingTime > 0f)
            movingTime -= Time.deltaTime;
        else
        {
            Vector3 newPos = new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), Random.Range(minRange.z, maxRange.z));
            movingTime = Random.Range(0.5f, 1.5f);
            transform.DOMove(newPos, movingTime);
        }

        if (notShootedTime < ShootInterval)
        {
            notShootedTime += Time.deltaTime;
            float currentRedColor = Mathf.Lerp(0f, 1f, notShootedTime / ShootInterval);
            GetComponentInChildren<Renderer>().material.SetVector("_Color", new Vector4(currentRedColor, 0f, 0f, 1f));
        }
        else
        {
            notShootedTime = 0f;
            ui.HitCharacter(0.1f);
        }

        transform.LookAt(cameraPos);
    }
}
