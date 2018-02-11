using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //добавляем для работы с UI
using UnityEngine;

public class UiController : MonoBehaviour {
	[SerializeField] private Text scoreLabel1; //объект, предназначенный для работы с текстом на UI
	[SerializeField] private Text scoreLabel2;
	[SerializeField] private WindowT wt; //переменая для работы с окном сообщения о завершении уровня
	private int _bullets; //переменая для хранения значения пуль
	private int _hit; //переменная для отслеживания количества попаданий

	void Awake(){
		Messenger.AddListener (GameEvent.BULLET, OnEnemyBul); //добавляем подписчика на OnEnemyBul
		Messenger.AddListener(GameEvent.HIT, OnEnemyHit); 
	}

	void OnDestory(){
		Messenger.RemoveListener (GameEvent.BULLET, OnEnemyBul); //удаляем подписчика на OnEnemyBul
		Messenger.RemoveListener(GameEvent.HIT, OnEnemyHit);
	}

	// Use this for initialization
	void Start () {
		wt.Close ();
		_bullets = 20;
		_hit = 0;
		scoreLabel1.text = _bullets.ToString (); //выводим начальное колличество патронов
		scoreLabel2.text = _hit.ToString ();
	}

	void OnEnemyBul () { //уменьшаем их при каждом выстреле
		_bullets -= 1;
		if (_bullets == 0) {
			wt.Open ();
		}
		scoreLabel1.text = _bullets.ToString ();
	}

	void OnEnemyHit () { //увеличиваем счетчик попаданий
		_hit += 1;
		scoreLabel2.text = _hit.ToString ();
	}


}
