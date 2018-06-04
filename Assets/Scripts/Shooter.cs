using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shooter : MonoBehaviour {

    public UiController iuc;
    public GameObject dec;

    private float timeSinceSecondButton = 100f;
    private int colorMode = 0;

    void Update () {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				Vector3 fwd = transform.TransformDirection (Vector3.forward);
			    iuc.EnemyBul (); // вызываем метод в UIController для уменьшения числа пуль
				if (Physics.Raycast (transform.position, fwd, out hit)) {	
					GameObject hitObject = hit.transform.gameObject; //получаем объект попадания
                Debug.Log(hitObject.name);
					Contr cn = hitObject.GetComponent<Contr> (); //проверяем наличие метода, если есть дырку от пули не создаем
					if (cn == null && SceneManager.GetActiveScene().name != "8") {
						GameObject hitObjectP = Instantiate (dec); //создаем отверстие от пули и выравниваем его по нормали
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
                    BarrelingExplosion barellExploion = hitObject.GetComponent<BarrelingExplosion>();//проверяем есть ли метод BarrelingExplosion
				    MovementBall moveBall = hitObject.GetComponent<MovementBall>();
				    HitLamp hitLamp = hitObject.GetComponent<HitLamp> ();
				if (target != null) {
					iuc.EnemyHit (); // вызываем метод в UIController для увеличения числа попаданий в мишень
					target.ReactToHit ();
				} else if (ufo != null) {
					iuc.EnemyHit ();
					ufo.ReactToHit1 ();
				} else if (barell != null) {
					iuc.EnemyHit ();
					barell.ReactToHitBarrel ();
				} else if (barellExploion != null) {
					iuc.EnemyHit ();
					barellExploion.ReactToHitBarrelExplosion ();
				} else if (moveBall != null) {
					moveBall.BallRotationR ();
				} else if (hitLamp != null) {
					iuc.EnemyHit ();
					hitLamp.Hit ();
				}

				}
			}
        if (Input.GetMouseButtonDown(1)) {
            if (SceneManager.GetActiveScene().name == "8")
            {
                if (timeSinceSecondButton > 0.5f)
                {
                    colorMode = (colorMode + 1) % 4;
                    var flashlightObject = GameObject.Find("Flashlight");
                    var light = flashlightObject.GetComponent<Light>();
                    switch (colorMode)
                    {
                        case 1: light.color = new Color(1f, 0.2f, 0.2f); break;
                        case 2: light.color = new Color(0.2f, 1f, 0.2f); break;
                        case 3: light.color = new Color(0.2f, 0.2f, 1f); break;
                        case 0: light.color = new Color(1f, 1f, 1f); break;
                    }
                    timeSinceSecondButton = 0f;
                }
                return;
            }
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			if (Physics.Raycast (transform.position, fwd, out hit)) {

				GameObject hitObject = hit.transform.gameObject;
				MovementBall moveBall = hitObject.GetComponent<MovementBall>();
				if (moveBall != null) {
					moveBall.BallRotationL ();
				}
			}
		}
        else
        {
            if (timeSinceSecondButton < 100f)
                timeSinceSecondButton += Time.deltaTime;
        }
    } 
}
