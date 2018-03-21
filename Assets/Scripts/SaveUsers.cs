using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;




[System.Serializable]
public class SaveUsers { //сериализованый класс для хранения данных пользователя
	public int Hit {get{ return _hit;} set{ _hit = value;}}
	public int Bullet {get{ return _bullet;} set{ _bullet = value;}}
	public float Minute {get{ return _minute;} set{ _minute = value;}}
	public float Second {get{ return _second;} set{ _second = value;}}
	public string Scene {get{ return _scene;} set{ _scene = value;}}
	int _hit;
	int _bullet;
	float _minute;
	float _second;
	string _scene;
}

public static class WriteUserOnDisk //метод записи в файл
{
	static string nameUser = PlayerPrefs.GetString("NameGame"); //узнаем будущие имя файла
	public static void SaveUser(SaveUsers su)//метод записывает в файл
	{
		if(!Directory.Exists(Application.dataPath + "/Saves")){ //проверяем, есть ли директория, если нет - создаем
			Directory.CreateDirectory (Application.dataPath + "/Saves");
		}
		FileStream fs = new FileStream (Application.dataPath + "/Saves/" + nameUser +".sv", FileMode.Create);//открываем поток для работы бинарными данными
		BinaryFormatter format = new BinaryFormatter (); //форматор для сериализации данных
		format.Serialize (fs, su); //заносим данные в поток
		fs.Close ();//закрываем поток
	}
}

public static class ReadUserWithDisk //извлекаем информацию из файла
{
	//static string nameUser;
	static SaveUsers su;
	public static SaveUsers ReturnSaveUsers(string nameUser)
	{
		//nameUser = name;
		if (File.Exists (Application.dataPath + "/Saves/" + nameUser +".sv")) { //проверяем, есть ли файл сохранения
			FileStream fs = new FileStream (Application.dataPath + "/Saves/" + nameUser +".sv", FileMode.Open); //открываем поток
			BinaryFormatter format = new BinaryFormatter (); //форматор для сериализации
			try{ 
				su = (SaveUsers)format.Deserialize(fs); //десериализуем нашу информации
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

		return su;
	}


}

