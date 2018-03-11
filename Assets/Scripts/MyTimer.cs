using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MyTimer : MonoBehaviour {
	public float startMinute; //задаем кол-во минут при старте
	public float startSecond; //задаем кол-во секунд при старте
	public bool start = false;
	//переменные для связи с канвой
	public Text min; 
	public Text sec; 
	public UnityEvent TimeEvent; //система сообщений для передачи сигнала, что время истекло
	// Use this for initialization

	void Start () { 
		StartCoroutine (StartTime ()); //стартуем таймер
	}

	 IEnumerator StartTime()
	{
		while (start) {  //цикл для расчета времени (организован сопрограммой)
			TimeCount ();
			yield return new WaitForSeconds (1);
		}
	}

	void TimeCount()
	{
		if (startSecond < 0) { //если секунды меньше 0, обновляем до 59
			startSecond = 59;
			startMinute--; //отнимаем одну минуту
		}

		if (startMinute < 0) { //как только значения минут станет меньше 0, останавливаем таймер
			start = false;
			if (TimeEvent != null) {
				TimeEvent.Invoke ();//отправляем подписчикам сообщение, что таймер закончил счет
			}
			return;
		}
		CurrentTime (); //метод для вывода значений таймера на экран
		startSecond--; //отнимаем секунды
	}

	void CurrentTime() //кратко о том, как на экране выводится время
	{
		if (startMinute < 10) {
			min.text = "0" + startMinute.ToString ();
		} 
		else {
			min.text = startMinute.ToString ();
		}
		if (startSecond < 10) {
			sec.text = "0" + startSecond.ToString ();
		} 
		else {
			sec.text = startSecond.ToString ();
		}

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
