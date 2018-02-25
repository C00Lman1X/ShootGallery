using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //добавляем для работы с UI
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour {
	public Text scoreLabel1; //объект, предназначенный для работы с текстом на UI
	public Text scoreLabel2;
	public WindowT wt; //переменая для работы с окном сообщения о завершении уровня
	public int _bullets; //переменая для хранения значения пуль
	public int _hit; //переменная для отслеживания количества попаданий

	void Start () {
		wt.Close (); // закрываем  окно с сообщением о завершении уровня
		scoreLabel1.text = _bullets.ToString (); //выводим начальное колличество патронов
		scoreLabel2.text = _hit.ToString (); //выводим начальное колличество попаданий
	}

	public void Str(int i) // функция для получения сообщений от класса RaySooter
	{
		if (i == 1) {
			OnEnemyBul ();
		} 
		else {
			OnEnemyHit ();
		}
	}
	void OnEnemyBul () { //уменьшаем их при каждом выстреле
		if (_bullets != 0) {
			_bullets -= 1;
		}
		if (_bullets == 0) {
			wt.Open ();

			Invoke ("Exit", 3f);
		}
		scoreLabel1.text = _bullets.ToString ();
	}

	void OnEnemyHit () { //увеличиваем счетчик попаданий
		_hit += 1;
		scoreLabel2.text = _hit.ToString ();
	}

	void Exit() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene (1);
	}
}
