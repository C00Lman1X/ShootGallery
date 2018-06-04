using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour {

    //float peed = 10f;
    float speedenemy = 0.02f;
    public GameObject LeftTrack;
    public GameObject RightTrack;
    public float tracksSpeed = 1f;

    float speed = 100f;

    public float minAngle = 0.0F;
    public float maxAngle = 90.0F;

    void Update () {
        transform.Translate(new Vector3(0f, 0f, speedenemy)); //перемещаем танк

        //движение левой и правой гусеницы
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        transform.Rotate(new Vector3(0f, speed, 0f));
    }
}
