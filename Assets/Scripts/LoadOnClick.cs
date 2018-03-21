using UnityEngine;
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
	int NButton;

	int continue1 = 0;
	void Start()
	{
		newUser.Close ();
		saveUsers.Close ();

	}
    public void LoadScene() //кнопка ОК в окне регистрации
    {
		if(continue1 == 1){continue1 = 0; PlayerPrefs.SetInt ("continue", continue1);} //проверяем, если пользователь щелкнул по продолжить. вернуть значение на 0
		name = IF.text; //узнаем логин пользователя
		PlayerPrefs.SetString("NameGame", name); //заносим в реестр
		SceneManager.LoadScene(2); //грузим сцену
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
			string[] user = Directory.GetFiles (Application.dataPath + "/Saves/", "*.sv", SearchOption.TopDirectoryOnly);//считываем с директории все файлы
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
		SaveUsers su = ReadUserWithDisk.ReturnSaveUsers (name); //загружаем его данные
		name = su.Scene; //узнаем, на какой он сцене
		SceneManager.LoadScene (name); //загружаем сцену
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
