using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlUFO : MonoBehaviour {
	
	public ParticleSystem part;
	public float speed;
	public bool LeftOrRight = false;
	public void ReactToHit1 ()
	{
		StartCoroutine (Die ());
	}

	private IEnumerator Die ()
	{
		speed = 0f;
		part.Play ();
		GetComponent<Rigidbody> ().useGravity = true;
		yield return new WaitForSeconds (5.0f);
		Destroy (this.gameObject);
	}

	void OnCollisionEnter()
	{
		speed = 0f;
		GetComponent<Rigidbody> ().useGravity = true;

	}
	void Start () {
		if (part != null) {
			part.Stop ();
		}
		speed = 1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (LeftOrRight == false) {
			GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * speed);
			Destroy (this.gameObject, 12);
		} 
		else if (LeftOrRight == true) {
			GetComponent<Rigidbody> ().AddRelativeForce (-Vector3.forward * speed);
			Destroy (this.gameObject, 12);
		}
	}
}
