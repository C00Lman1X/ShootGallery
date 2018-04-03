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
    public int targetCount = 0; // количество противников на сцене
	public UnityEvent EndLevel;
	public WindowT fon;
	public Image process1;
	public Text percent;
	public bool WinScene5 = false;

    void Start () {
		
		//wt.Close ();
		scoreLabel1.text = _bullets.ToString (); //выводим начальное колличество патронов
		scoreLabel2.text = _hit.ToString (); //выводим начальное колличество попаданий
		fon.Close();
	}


	public void EnemyBul () { //уменьшаем их при каждом выстреле
		if (_bullets != 0) {
			_bullets -= 1;
		}
		if (_bullets == 0) {
			EndLevel.Invoke ();
			//wt.Open ();

			//Invoke ("Exit", 3f);
		}
		scoreLabel1.text = _bullets.ToString ();
	}

	public void EnemyHit () { //увеличиваем счетчик попаданий
        targetCount--;
		_hit += 1;
		scoreLabel2.text = _hit.ToString ();


	}

    public void HitCharacter(float damage)
    {
        // TODO: уменьшение жизней
    }

	IEnumerator Aset(int i)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (i);
		while (!operation.isDone) {
			float load = operation.progress / 0.9f;
			process1.fillAmount = load;
			percent.text = string.Format ("{0:0}%", load*100f);
			yield return null;
		}
	}
    //Переключение между уровнями
	public void Exit(string i, bool victory) {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        //string i = SceneManager.GetActiveScene().name;
		if (i == "1" && victory == true) {
			fon.Open ();
			StartCoroutine (Aset (3));
		} 
		else if (i == "1" && victory == false) {
			fon.Open ();
			StartCoroutine (Aset (1));
		} 
		else if (i == "2" && victory == true) {
			fon.Open ();
			StartCoroutine (Aset (4));
		} 
		else if (i == "2" && victory == false) {
			fon.Open ();
			StartCoroutine (Aset (3));
		} 
		else if (i == "3" && victory == true) {
			fon.Open ();
			StartCoroutine (Aset (5));
		} 
		else if (i == "3" && victory == false) {
			fon.Open ();
			StartCoroutine (Aset (4));
		}
        else if (i == "4" && victory == true)
        {
			fon.Open ();
			StartCoroutine (Aset (6));
        }
        else if (i == "4" && victory == false)
        {
			fon.Open ();
			StartCoroutine (Aset (5));
        }
		else if (i == "5" && victory == true)
		{
			fon.Open ();
			StartCoroutine (Aset (0));
		}
		else if (i == "5" && victory == false)
		{
			fon.Open ();
			StartCoroutine (Aset (6));
		}
        else
        {
			fon.Open ();
			StartCoroutine (Aset (0));
        }
	}
}
