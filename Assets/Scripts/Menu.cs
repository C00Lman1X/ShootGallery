using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
	public WindowT windowMenu;
	public GameObject Gun;
	bool pause = false;
	string nameUser;
	List<string> ls;
		
	// Use this for initialization
	void Start () {
		windowMenu.Close (); //закрываем пункт меню при старте
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { //нажата ли кнопка Esc
			if (!pause) { //pause == false - то значит запускаем паузу
				pause = true;
				Time.timeScale = 0;//тормозим сцену
				Gun.SetActive (false); //пистолет мешает
				Cursor.lockState = CursorLockMode.None; //курсор возвращаем
				Cursor.visible = true;
				windowMenu.Open (); //окрываем окно паузы
			} 
			else {
				StartGame (); //медод возврата в игру вынесен отдельно т.к. нужен и для раборы с кнопкой "продолжить"
			}
		}
	}

	public void StartGame()
	{
		pause = false;
		windowMenu.Close ();
		Time.timeScale = 1; //запускается сцена
		Gun.SetActive (true); //активируем пистолет
		Cursor.lockState = CursorLockMode.Locked; //прячем курсор
		Cursor.visible = false;
	}

	public void Save() //сохраняем игру
	{
		//заносит туда параметры, которые хотим сохранить
		SaveUsers su = new SaveUsers();
		su.Hit = GetComponent<UiController> ()._hit; //число попаданий
		su.Bullet = GetComponent<UiController> ()._bullets; //кол-во пуль
		su.Minute = GetComponent<MyTimer> ().startMinute;//минуты и секунды
		su.Second = GetComponent<MyTimer> ().startSecond;
		su.Scene = SceneManager.GetActiveScene().name;
		WriteUserOnDisk.SaveUser (su);

	}

	public void Load() //загрузка сохраненных данных
	{
		
		nameUser = PlayerPrefs.GetString ("NameGame");
		//SaveUsers su = ReadUserWithDisk.ReturnSaveUsers (nameUser);
		//задаем параметры 
		GetComponent<UiController> ()._hit = LoadOnClick.su.Hit;//su.Hit; 
		GetComponent<UiController> ()._bullets =LoadOnClick.su.Bullet;  //su.Bullet;
		GetComponent<MyTimer> ().startMinute = LoadOnClick.su.Minute; //su.Minute;
		GetComponent<MyTimer> ().startSecond = LoadOnClick.su.Second;//su.Second;
		GetComponent<UiController>().scoreLabel1.text =LoadOnClick.su.Bullet.ToString();  //su.Bullet.ToString(); //отображаем значения для пользователя
		GetComponent<UiController>().scoreLabel2.text = LoadOnClick.su.Hit.ToString(); //su.Hit.ToString();
	}

	public void ExitMenu() //выходим в главное меню
	{
		PlayerPrefs.DeleteKey ("NameGame");
		SceneManager.LoadScene(0);
	}
}
