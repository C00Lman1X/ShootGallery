using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCotrl : MonoBehaviour {
	[SerializeField] private GameObject enemy1; //переменные для связи с перфабом и слижением за ним на сцене
	private GameObject _enemy;
    public float pozXmin = -8.0f;
    public float pozXmax = 8.0f;
    public float pozZmin = 0.0f;
    public float pozZmax = 17.0f;
    public string target_1;
    public string target_2;
    public string target_3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float i = Random.Range (0, 3);
		if (_enemy == null) { //если нет объекта на сцене создаем
			_enemy = Instantiate (enemy1) as GameObject;
			//при создании объекта текстура накладывается в процессе игры из папки Resources
			if(i == 0){ _enemy.GetComponent<Renderer> ().material.mainTexture = Resources.Load (target_1) as Texture;}
			if(i == 1){ _enemy.GetComponent<Renderer> ().material.mainTexture = Resources.Load (target_2) as Texture; }
			if(i == 2){ _enemy.GetComponent<Renderer> ().material.mainTexture = Resources.Load (target_3) as Texture; }
			//устанавливаем кардинаты
			float pos_x = Random.Range (pozXmin, pozXmax);
			float pos_z = Random.Range (pozZmin, pozZmax);
			_enemy.transform.position = new Vector3 (pos_x, 3.03f, pos_z);
			Destroy (_enemy, 1f); //через некоторое время удалить объект
		}
	}
}
