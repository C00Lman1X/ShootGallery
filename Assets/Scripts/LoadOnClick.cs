using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadOnClick : MonoBehaviour {
	string name;

	int continue1 = 0;
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
	public void ContinueScene() //метод кнопки продолжить
	{
		continue1 = 1; //переменная для сообщения загружаемой сцене, что надо подгрузить сохраненные даные
		PlayerPrefs.SetInt ("continue", continue1);//записываем в реестр значение переменной
		name = PlayerPrefs.GetString ("NameScene"); //считываем из реестра ранее записаное имя сцены
		//PlayerPrefs.DeleteKey ("NameScene");
		SceneManager.LoadScene (name); //загружаем сцену
	}

	public void TheEnd() //метод кнопки завершить
	{
		Application.Quit ();
	}
}
