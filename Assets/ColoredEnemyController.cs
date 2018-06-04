using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredEnemyController : MonoBehaviour {
    
    private Vector3 direction;
    private float distance;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private float localTime = 0f;
    private float allTime;

    private float xOffset = 0f;
    private float yOffset = 0f;

    public float speed;
    
	void Start () {
        var player = GameObject.Find("FixedCameraCharacter");
        endPosition = player.transform.position;
        startPosition = transform.position;

        direction = (endPosition - startPosition).normalized;
        distance = (endPosition - startPosition).magnitude;

        allTime = distance / speed;
    }
	
	void Update ()
    {
        localTime += Time.deltaTime;

        float t = localTime / allTime;
        var position = Vector3.Lerp(startPosition, endPosition, t);
        xOffset = Mathf.Sin(localTime);
        yOffset = Mathf.Cos(localTime);
        transform.position = new Vector3(position.x + xOffset, position.y + yOffset, position.z);
    }
}
