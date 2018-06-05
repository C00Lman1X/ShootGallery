using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredEnemyController : MonoBehaviour {
    private Vector3 startPosition;
    private Vector3 endPosition;
    private UiController ui;
    private ReactiveTarget reactiveTarget;

    private float localTime = 0f;
    private float allTime;

    private float xOffset = 0f;
    private float yOffset = 0f;
    
    private int color;

    public float speed;
    
	void Start () {
        ui = GameObject.Find("Canvas").GetComponent<UiController>();
        reactiveTarget = gameObject.GetComponent<ReactiveTarget>();

        var player = GameObject.Find("Main Camera");
        endPosition = player.transform.position;
        startPosition = transform.position;

        var distance = (endPosition - startPosition).magnitude;
        allTime = distance / speed;
    }
	
	void Update ()
    {
        localTime += Time.deltaTime;

        if (reactiveTarget.IsDead())
            return;

        float t = localTime / allTime;
        var position = Vector3.Lerp(startPosition, endPosition, t);
        float yCorrect = 0f;
        xOffset = Mathf.Sin(localTime);
        yOffset = Mathf.Cos(localTime);
        if (position.y - 1f < 0.5f)
            yCorrect = 1.5f;
        transform.position = new Vector3(position.x + xOffset, position.y + yOffset + yCorrect, position.z);

        if (transform.position.z < -8f)
        {
            Destroy(transform.parent.gameObject);
            ui.HitCharacter(0.1f);
        }
    }

    public void SetColor(int c)
    {
        color = c;
        Vector4 materialColor;
        switch (color)
        {
            case 1: materialColor = new Vector4(1f, 0f, 0f, 1f); break;
            case 2: materialColor = new Vector4(0f, 1f, 0f, 1f); break;
            case 3: materialColor = new Vector4(1f, 1f, 0f, 1f); break;
            default: materialColor =new Vector4(1f, 1f, 1f, 1f); break;
        }
        //GetComponentInChildren<Renderer>().materials[0].SetVector("_Color", materialColor);
        GetComponent<Renderer>().materials[1].SetVector("_Color", materialColor);
        GetComponent<Renderer>().materials[2].SetVector("_Color", materialColor);
        GetComponent<Renderer>().materials[3].SetVector("_Color", materialColor);
    }

    public int GetColor() { return color; }
}
