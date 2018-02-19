using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySooter : MonoBehaviour {

	private Camera _camera;
	[SerializeField] private GameObject dec;//переменная для дырки от пули
	[SerializeField] private Texture2D aim; //переменная для текстуры
	[SerializeField] private GameObject iuc; //переменная для объекта UI

	// Use this for initialization


	void Start () {
		_camera = GetComponent<Camera> ();//получаем доступ к присоединенным компонентам

		Cursor.lockState = CursorLockMode.Locked; //скрываем указатель мыши
		Cursor.visible = false;
	}


	void Update () {
		if (Input.GetMouseButtonDown (0)) { //после нажатия кнопки выпускаем луч из центра экрана
			iuc.GetComponent<UiController>().Str(1); //вызываем метод в UIController для уменьшения числа пуль
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) { //в случае попадания 
				GameObject hitObject = hit.transform.gameObject; //получаем объект попадания
				Contr cn = hitObject.GetComponent<Contr> (); //проверяем наличие метода, если есть дырку от пули не создаем
				if (cn == null) {
					GameObject hitObjectP = hitObject; 
					hitObjectP = Instantiate<GameObject> (dec); //создаем отверстие от пули и выравниваем его по нормали
					hitObjectP.transform.position = hit.point + hit.normal * 0.01f;
					hitObjectP.transform.rotation = Quaternion.LookRotation (-hit.normal);
					hitObjectP.transform.SetParent (hit.transform); //назначаем родителем объект попадания
				} 
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();//проверяем есть ли метод ReactiveTarget
				if (target != null) { 
					iuc.GetComponent<UiController> ().Str (2); // вызываем метод в UIController для увеличения числа попаданий в мишень
					target.ReactToHit ();
				} 
			}
		}
	}
}
