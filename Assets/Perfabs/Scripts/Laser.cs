using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public float timeBetweenShots = 0.15f;
	public float range = 100f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shoottableMask;

	LineRenderer gunLine;

	public float effectsDisplayTime = 0.2f;
	bool isShooting = false;

	void Awake(){
		//shoottableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent<LineRenderer> (); //получаем ссылку на компонент LineRenderer
		DisableEffects (); //отключить линию
	}

	public void StartShootGun(){//запускаем лазер
		isShooting = true;
	
	} 

	public void StopShootGun(){//выключаем лазер
		isShooting = false;

	} 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; //таймер
		if (isShooting == true && timer >= timeBetweenShots) {
			Shoot ();
		}
		if (timer >= timeBetweenShots * effectsDisplayTime) {
			DisableEffects ();
		}
	}

	public void DisableEffects (){
		gunLine.enabled = false; //отключить линию
	}

	void Shoot(){
		timer = 0f;
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
	}
}
