using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCotrl : MonoBehaviour {
	[SerializeField] private GameObject enemy1; //переменные для связи с перфабом и слижением за ним на сцене
	private GameObject _enemy;
	public GameObject iuc;
	bool liveObject = false;

	// Use this for initialization
	void Start () {
		
	}

	bool Hit_ten()
	{
		if (iuc.GetComponent<UiController> ()._hit == 10) {liveObject = true;}
		return liveObject;
	}
	// Update is called once per frame
	void Update () {
		int i = Random.Range (0, 3);
		if (_enemy == null & Hit_ten () == false) { //если нет объекта на сцене создаем
			_enemy = Instantiate (enemy1) as GameObject;
			//при создании объекта текстура накладывается в процессе игры из папки Resources
			if (i == 0) {
				_enemy.GetComponent<Renderer> ().material.mainTexture = Resources.Load ("Man") as Texture;
			}
			if (i == 1) {
				_enemy.GetComponent<Renderer> ().material.mainTexture = Resources.Load ("Mars") as Texture;
			}
			if (i == 2) {
				_enemy.GetComponent<Renderer> ().material.mainTexture = Resources.Load ("Rob") as Texture;
			}
			//устанавливаем кардинаты
			float pos_x = Random.Range (0.0f, 8.0f);
			float pos_z = Random.Range (0.0f, 17.0f);
			_enemy.transform.position = new Vector3 (pos_x, 3.03f, pos_z);
			Destroy (_enemy, 1f); //через некоторое время удалить объект
		} 

	}
}
