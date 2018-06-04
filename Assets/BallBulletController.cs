using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBulletController : MonoBehaviour
{
    public Transform finalPos;
    public UiController ui;
    public float speed = 1f;

    private Vector3 direction;

    void Start()
    {
        transform.LookAt(finalPos);
        direction = finalPos.position - transform.position;
        direction.Normalize();
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter()
    {
        ui.HitCharacter(10);
        Debug.Log(ui._bullets);
        Destroy(this.gameObject);
    }
}