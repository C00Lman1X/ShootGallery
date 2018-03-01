﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public float sensitivitHor = 9.0f;
	public float sensitivitVert = 9.0f;
    public float minVert, maxVert;
    public float minHor, maxHor;
    
    public GameObject target;
    private Vector3 rotationAngles;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	void Update () {
        rotationAngles.y = Mathf.Clamp(rotationAngles.y + Input.GetAxis("Mouse X") * sensitivitHor, minHor, maxHor);
        rotationAngles.x = Mathf.Clamp(rotationAngles.x - Input.GetAxis("Mouse Y") * sensitivitVert, minVert, maxVert);
        transform.eulerAngles = rotationAngles;
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast (transform.position, fwd, out hit)) {
			SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();
			renderer.enabled = true;
			target.transform.position = hit.point;
		}
		else {
			SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();
			renderer.enabled = false;
		}
    }
}
