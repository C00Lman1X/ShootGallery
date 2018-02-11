using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowT : MonoBehaviour { //работаем с окном вывоящем сообщение о завершении уровня

	public void Open(){
		gameObject.SetActive (true); //открываем окно
	}

	public void Close(){
		gameObject.SetActive (false); //закрываем окно
	}
}
