using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySooter : MonoBehaviour {

	private Camera _camera;
	public GameObject dec;//переменная для дырки от пули
	public Texture2D aim; //переменная для текстуры

	// Use this for initialization


	void Start () {
		_camera = GetComponent<Camera> ();//получаем доступ к присоединенным компонентам

		Cursor.lockState = CursorLockMode.Locked; //скрываем указатель мыши
		Cursor.visible = false;
	}

	//void OnGUI() // устанавливаем прицел в центре экрана
	//{
		//int size = 12;
		//float posX = _camera.pixelWidth / 2 - size / 4;
		//float posY = _camera.pixelHeight / 2 - size / 2;
		//GUI.Label (new Rect (posX, posY, size, size), aim);
	//}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) { //после нажатия кнопки выпускаем луч из центра экрана
			Messenger.Broadcast(GameEvent.BULLET); //при выстреле идет рассылка сообщения подписчикам UI
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) { //в случае попадания 
				GameObject hitObject = Instantiate<GameObject>(dec); //создаем отверстие от пули и выравниваем его по нормали
				hitObject.transform.position = hit.point + hit.normal * 0.01f;
				hitObject.transform.rotation = Quaternion.LookRotation (-hit.normal);
				hitObject.transform.SetParent (hit.transform); //назначаем родителем объект попадания
				hitObject = hit.transform.gameObject; //получаем объект попадания
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();//проверяем есть ли метод ReactiveTarget
				if (target != null) { 
					Messenger.Broadcast (GameEvent.HIT);
					target.ReactToHit ();
				} 
			}
		}
	}
}
