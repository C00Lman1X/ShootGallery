using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlUFO : MonoBehaviour {
	
	public ParticleSystem part;
	public float speed;
	public bool LeftOrRight = false;
	RaycastHit hit;
	Vector3 fwd;

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

	void Update(){
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		fwd = transform.TransformDirection (Vector3.right);
		if (Physics.Raycast (transform.position, fwd, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			Contr cn = hitObject.GetComponent<Contr> ();
			if (cn != null) {
				GetComponentInChildren<Laser> ().StartShootGun ();
			} 
			else {
				GetComponentInChildren<Laser> ().StopShootGun ();
			}
		}
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
