using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Menu : MonoBehaviour {
	public WindowT windowMenu;
	public GameObject Gun;
	string nameScene;
	bool pause = false;

	[System.Serializable] 
	public class Value //сериализованный класс для работы с потоком даных, где будем хранить сохраненые значения
	{
		public int Hit
		{
			get{return hit;}
			set{ hit = value;}
		}
		public int Bullet
		{
			get{return bullet;}
			set{ bullet = value;}
		}
		public float Minute
		{
			get{return minute;}
			set{ minute = value;}
		}
		public float Second
		{
			get{return second;}
			set{ second = value;}
		}

		int hit;
		int bullet;
		float minute;
		float second;


	}
		
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
		Value vl = new Value (); //экземпляр класса
		//заносит туда параметры, которые хотим сохранить
		vl.Hit = GetComponent<UiController> ()._hit; //число попаданий
		vl.Bullet = GetComponent<UiController> ()._bullets; //кол-во пуль
		vl.Minute = GetComponent<MyTimer> ().startMinute;//минуты и секунды
		vl.Second = GetComponent<MyTimer> ().startSecond;
		if(!Directory.Exists(Application.dataPath + "/Saves")){ //проверяем, есть ли директория, если нет - создаем
			Directory.CreateDirectory (Application.dataPath + "/Saves");
		}
		FileStream fs = new FileStream (Application.dataPath + "/Saves/gameSave.sv", FileMode.Create);//открываем поток для работы бинарными данными
		BinaryFormatter format = new BinaryFormatter (); //форматор для сериализации данных
		format.Serialize (fs, vl); //заносим данные в поток
		fs.Close ();//закрываем поток
		nameScene = SceneManager.GetActiveScene ().name;
		PlayerPrefs.SetString ("NameScene", nameScene);//заносим имя текущей сцены в реестр
	}

	public void Load() //загрузка сохраненных данных
	{
		if (File.Exists (Application.dataPath + "/Saves/gameSave.sv")) { //проверяем, есть ли файл сохранения
			FileStream fs = new FileStream (Application.dataPath + "/Saves/gameSave.sv", FileMode.Open); //открываем поток
			BinaryFormatter format = new BinaryFormatter (); //форматор для сериализации
			try{ 
				Value vl = (Value)format.Deserialize(fs); //десериализуем нашу информацию
				//задаем параметры
				GetComponent<UiController> ()._hit = vl.Hit; 
				GetComponent<UiController> ()._bullets = vl.Bullet;
				GetComponent<MyTimer> ().startMinute = vl.Minute;
				GetComponent<MyTimer> ().startSecond = vl.Second;
				GetComponent<UiController>().scoreLabel1.text = vl.Bullet.ToString(); //отображаем значения для пользователя
				GetComponent<UiController>().scoreLabel2.text = vl.Hit.ToString();


			}
			catch (System.Exception e){
				Debug.Log (e.Message); //если возникла ошибка на этапе десериализации
			}
			finally{
				fs.Close ();
			}
		} 
		else {
			Application.Quit ();//при фатальной ошибке, выходим из игры
		}
	}
	public void ExitMenu() //выходим в главное меню
	{
		SceneManager.LoadScene(0);
	}
}
