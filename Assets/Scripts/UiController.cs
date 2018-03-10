﻿using System.Collections;
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

    public int targetCount = 0; // количество противников на сцене


    void Start () {
		wt.Close ();
		scoreLabel1.text = _bullets.ToString (); //выводим начальное колличество патронов
		scoreLabel2.text = _hit.ToString (); //выводим начальное колличество попаданий
	}

	public void EnemyBul () { //уменьшаем их при каждом выстреле
		if (_bullets != 0) {
			_bullets -= 1;
		}
		if (_bullets == 0) {
			wt.Open ();

			Invoke ("Exit", 3f);
		}
		scoreLabel1.text = _bullets.ToString ();
	}

	public void EnemyHit () { //увеличиваем счетчик попаданий
        targetCount--;
		_hit += 1;
		scoreLabel2.text = _hit.ToString ();
		if (_hit == 10) {
			
		}

	}

    public void HitCharacter(float damage)
    {
        // TODO: уменьшение жизней
    }


    //Переключение между уровнями
	void Exit() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        string i = SceneManager.GetActiveScene().name;
        if (i == "1")
        {
            SceneManager.LoadScene(3);
        }
        else if (i == "2")
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
	}
}
