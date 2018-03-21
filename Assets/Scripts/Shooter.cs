using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour {

    public UiController iuc;
    public GameObject dec;

    void Update () {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				Vector3 fwd = transform.TransformDirection (Vector3.forward);
				if (Physics.Raycast (transform.position, fwd, out hit)) {
					iuc.EnemyBul (); // вызываем метод в UIController для уменьшения числа пуль
					GameObject hitObject = hit.transform.gameObject; //получаем объект попадания
					Contr cn = hitObject.GetComponent<Contr> (); //проверяем наличие метода, если есть дырку от пули не создаем
					if (cn == null) {
						GameObject hitObjectP = hitObject;
						hitObjectP = Instantiate (dec); //создаем отверстие от пули и выравниваем его по нормали
						hitObjectP.transform.position = hit.point + hit.normal * 0.01f;
						hitObjectP.transform.rotation = Quaternion.LookRotation (-hit.normal);
						hitObjectP.transform.SetParent (hit.transform); //назначаем родителем объект попадания
						Rigidbody r = hit.transform.gameObject.GetComponent<Rigidbody> (); //проверяем наличие 
						if (r != null) {
							r.AddForceAtPosition (-hit.normal * 100f, hit.point);
						}
					}
					ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();//проверяем есть ли метод ReactiveTarget
					ControlUFO ufo = hitObject.GetComponent<ControlUFO> ();
                    Barreling barell = hitObject.GetComponent<Barreling>();//проверяем есть ли метод Barreling
                    if (target != null) {
						iuc.EnemyHit (); // вызываем метод в UIController для увеличения числа попаданий в мишень
						target.ReactToHit ();
					} else if (ufo != null) {
						iuc.EnemyHit ();
						ufo.ReactToHit1 ();
					} else if (barell != null) {
						iuc.EnemyHit ();
                        barell.ReactToHitBarrel ();
					}
				}
			}
    }
}
