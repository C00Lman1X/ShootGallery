using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPS : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;
	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float dX = Input.GetAxis ("Horizontal") * speed;
		float dY = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (dX, 0, dY);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		_charController.Move (movement);

	}
}
