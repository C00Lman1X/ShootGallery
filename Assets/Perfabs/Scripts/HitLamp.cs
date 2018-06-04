using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitLamp : MonoBehaviour {
	public GameObject lightLamp;
	public GameObject Lamp1;
	public bool OnOrOff = true;

	void Start(){
		Lamp1 = GameObject.Find ("Lamp");
	}

	public void Hit(){
		lightLamp.SetActive (false);
		OnOrOff = false;
		Lamp1.GetComponent<Lamp> ().Hit ();
	}

	public void On(){
		lightLamp.SetActive (true);
		OnOrOff = true;
	}
}
