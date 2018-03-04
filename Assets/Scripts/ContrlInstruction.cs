using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class ContrlInstruction : MonoBehaviour {

	[SerializeField] private Text txt;
	[SerializeField] private Toggle or_or;
	[SerializeField] private Button ok;
	[SerializeField] private Image pul;
	[SerializeField] private Image Target;
	[SerializeField] private Image Time1;
	[SerializeField] private Image Live;

	int ButtonOkOr = 0;
	// Use this for initialization
	void Start () {
		txt.text = "Хей! Добро пожаловать в тир! Здесь ты можешь испытать свою удачу, меткость и скорость." +
		"Новичкам рекомендую пройти обучение поставив галочку ниже." +
		"Опытным стрелкам просто нажать кнопку ОК";
		pul.gameObject.SetActive (false);
		Target.gameObject.SetActive (false);
		Time1.gameObject.SetActive (false);
		Live.gameObject.SetActive (false);
	}
		
	public void TaskOnClick()
	{
		if (or_or.isOn == false) {
			SceneManager.LoadScene (1);
		} 
		else {
			if (ButtonOkOr == 0) {
				or_or.gameObject.SetActive (false);
				txt.text = "Наш тир разделен на несколько уровней. При открытии каждого уровня появляется сообщение с " +
					"описанием задачи, которую тебе необходимо выполнить для перехода на следующий. ";
				ButtonOkOr = 1;
			}
			else if (ButtonOkOr == 1) {
				txt.text = "Управление прицелом осуществляется мышью. Выстрел левой кнопкой мыши.";
				ButtonOkOr = 2;
			}
			else if (ButtonOkOr == 2) {
				txt.text = "Изображение пули указывает на количество патронов.";
				pul.gameObject.SetActive (true);
				ButtonOkOr = 3;

			}
			else if (ButtonOkOr == 3) {
				pul.gameObject.SetActive (false);
				txt.text = "Изображение мишени сообщает о количестве попаданий в цель.";
				Target.gameObject.SetActive (true);	
				ButtonOkOr = 4;
			}

			else if (ButtonOkOr == 4) {
				Target.gameObject.SetActive (false);
				txt.text = "Изображение часов указывает на таймер.";
				Time1.gameObject.SetActive (true);	
				ButtonOkOr = 5;
			}
			else if (ButtonOkOr == 5) {
				Time1.gameObject.SetActive (false);
				txt.text = "Надпись Live сообщает о количестве оставшихся очков жизни.";
				Live.gameObject.SetActive (true);	
				ButtonOkOr = 6;
			}
			else if (ButtonOkOr == 6) {
				Live.gameObject.SetActive (false);
				txt.text = "Обучение завершено. Удачи!";
				ButtonOkOr = 7;

			}
			else if (ButtonOkOr == 7) {
				SceneManager.LoadScene (1);

			}
			}

	}
}
