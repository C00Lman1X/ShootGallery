using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementBall : MonoBehaviour {

	public float speed;
	public float ballDistance;
	float height;
	public UnityEvent EndLevel;
	public UiController iuc;

	// Use this for initialization
	void Start () {
		Ray ray = new Ray (transform.position, -transform.up); //получаем высоту над полом
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			height = hit.distance;
		}

	}

	public void BallRotationR()
	{
		transform.Rotate (0, 90f, 0);
	}

	public void BallRotationL()
	{
		transform.Rotate (0, -90f, 0);
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime); // непрерывное движение вперед
		//поворачиваем на 90 если впереди препятствие
		Ray ray = new Ray (transform.position, transform.forward); 
		RaycastHit hit;
		if(Physics.SphereCast(ray, 0.3f, out hit)){
			if(hit.distance < ballDistance){
				transform.Rotate (0, 90f, 0);
			}
		}
		//т.к. движение по наклонной плоскости контролируем высоту над полом
		Ray ray1 = new Ray (transform.position, -transform.up);
		RaycastHit hit1;
		if(Physics.Raycast(ray1, out hit1)){ //если под шариком область завершения уровня
			GameObject hitObject = hit1.transform.gameObject;
			string cn = hitObject.tag;
			if (cn == "Respawn") {
				iuc.WinScene5 = true;
				EndLevel.Invoke ();
			} else {
				if (hit1.distance < height) {
					transform.Translate (0, height * Time.deltaTime, 0);

				} else if (hit1.distance > height) {
					transform.Translate (0, -height * Time.deltaTime, 0);

				}
			}
		}
	}
}
