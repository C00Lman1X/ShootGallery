﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LoadOnClick : MonoBehaviour {
	public string name;
	public InputField IF;
	public WindowT newUser;
	public WindowT saveUsers;
	public Text[] variantSave; 
	public WindowT fon;
	public Image process1;
	public Text percent;
	static public SaveUsers su; //для загрузки данных в скрипте Menu.Load() без вторичного считывания с файла
	int NButton;

	int continue1 = 0;
	void Start()
	{
		fon.Close ();
		newUser.Close ();
		saveUsers.Close ();

	}
	IEnumerator Aset(int i, string name)
	{
		AsyncOperation operation;
		if (name == "null") {
			operation = SceneManager.LoadSceneAsync (i);
		} else {
			operation = SceneManager.LoadSceneAsync (name);
		}
		while (!operation.isDone) {
			float load = operation.progress / 0.9f;
			process1.fillAmount = load;
			percent.text = string.Format ("{0:0}%", load*100f);
			yield return null;
		}
	}
    public void LoadScene() //кнопка ОК в окне регистрации
    {
		if(continue1 == 1){continue1 = 0; PlayerPrefs.SetInt ("continue", continue1);} //проверяем, если пользователь щелкнул по продолжить. вернуть значение на 0
		name = IF.text; //узнаем логин пользователя
		PlayerPrefs.SetString("NameGame", name); //заносим в реестр
		fon.Open ();
		StartCoroutine (Aset (2, "null")); //грузим сцену
    }
	public void ClikNewGame()
	{
		newUser.Open (); //открываем окно для регистрации по щелчку "Новая игра"
	}
	public void ContinueScene() //метод кнопки продолжить
	{
		continue1 = 1; //переменная для сообщения загружаемой сцене, что надо подгрузить сохраненные даные
		PlayerPrefs.SetInt ("continue", continue1);//записываем в реестр значение переменной
		saveUsers.Open (); //окно пользователей
		bool contrl = Directory.Exists (Application.dataPath + "/Saves"); //проверяем, есть ли папка Saves
		string way = Application.dataPath + "/Saves", file;
		if (contrl == true) {
			string[] user = Directory.GetFiles (Application.dataPath + "/Saves/", "*.sv", SearchOption.TopDirectoryOnly);//считываем с директория все файлы
			int j = user.Length, timevalue; string timename; //рабочие переменные
			for (int i = 0; i < j; i++) {
				//ниже способ узнать таки имя файла без пути и расширения
				timevalue = user[i].LastIndexOf('/') + 1; 
				timename = user [i].Substring (timevalue);
				timevalue = timename.LastIndexOf('.');
				timename = timename.Remove (timevalue);
				variantSave [i].text = timename;//пишем на кнопочках имена юзеров
			}
		} 
		else {
			saveUsers.Open (); //если папки Saves нет, то открываем пустое окно
		}
	}
	public void ChooseUser(int i) //если мы выбрали пользователя
	{
		NButton = i; //понадобится для удаления
		name = variantSave [NButton].text; //помещаем ключ в реестр, чтобы другая сцена смогла работать с именем пользователя
		PlayerPrefs.SetString("NameGame", name);
	}

	public void Choose() //если выбрали пользователя
	{
		su = ReadUserWithDisk.ReturnSaveUsers (name); //загружаем его данные
		name = su.Scene; //узнаем, на какой он сцене
		fon.Open ();
		StartCoroutine (Aset (0, name)); //грузим сцену
		//SceneManager.LoadScene (name); //загружаем сцену
	}
	public void DeleteUser() //удаляем пользователя
	{
		variantSave [NButton].text = " "; //очищаем надпись
		File.Delete (Application.dataPath + "/Saves/" + name +".sv"); //удаляем файл с диска

	}
	public void Cancel() //кнопка отмены
	{
		//PlayerPrefs.DeleteKey("NameGame"); //удаляем ключ, 
		saveUsers.Close (); //закрываем окно
	}

	public void TheEnd() //метод кнопки завершить
	{
		Application.Quit (); //завершаем игру
	}
}
