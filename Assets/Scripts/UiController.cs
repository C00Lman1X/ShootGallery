using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //добавляем для работы с UI
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour {
	public Text scoreLabel1; //объект, предназначенный для работы с текстом на UI
	public Text scoreLabel2;
    public Image redScreen;
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

    void Update() {
        if (redScreen && redScreen.color.a > 0f)
            redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, redScreen.color.a -  0.02f);
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
        redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, 0.5f);

        var slider = gameObject.GetComponentInChildren<Slider>();
        slider.value = Mathf.Max(0f, slider.value - damage);
        if (slider.value <= 0f)
            EndLevel.Invoke();
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
        fon.Open();
        if (i == "1")
        {
            if (victory)
                StartCoroutine (Aset (3));
            else
                StartCoroutine(Aset(1));
        }
		else if (i == "2")
        {
            if (victory)
                StartCoroutine (Aset (4));
            else
                StartCoroutine(Aset(3));
        }
        else if (i == "3")
        {
            if (victory)
                StartCoroutine (Aset (5));
            else
                StartCoroutine(Aset(4));
        }
        else if (i == "4")
        {
            if (victory)
                StartCoroutine (Aset (6));
            else
                StartCoroutine(Aset(5));
        }
		else if (i == "5")
        {
            if (victory)
                StartCoroutine (Aset (7));
            else
                StartCoroutine(Aset(6));
        }
		else if (i == "6")
        {
            if (victory)
                StartCoroutine(Aset(8));
            else
                StartCoroutine(Aset(7));
        }
        else if (i == "7")
        {
            if (victory)
                StartCoroutine(Aset(9));
            else
                StartCoroutine(Aset(8));
        }
        else if (i == "8")
        {
            if (victory)
                StartCoroutine(Aset(0));
            else
                StartCoroutine(Aset(9));
        }
        else
        {
			StartCoroutine (Aset (0));
        }
	}
}
