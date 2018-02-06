using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCotrl : MonoBehaviour {
	[SerializeField] private GameObject enemy1; //переменные для связи с перфабом и слижением за ним на сцене
	[SerializeField] private GameObject enemy2;
	[SerializeField] private GameObject enemy3;
	private GameObject _enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float i = Random.Range (0, 3);
		if (_enemy == null) { //если нет объекта на сцене создаем
			if(i == 0){ _enemy = Instantiate (enemy1) as GameObject; }
			if(i == 1){ _enemy = Instantiate (enemy2) as GameObject; }
			if(i == 2){ _enemy = Instantiate (enemy3) as GameObject; }
			//устанавливаем кардинаты
			float pos_x = Random.Range (0.0f, 8.0f);
			float pos_z = Random.Range (0.0f, 17.0f);
			_enemy.transform.position = new Vector3 (pos_x, 3.03f, pos_z);

		}
	}
}
