using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ProblemOfLevel : MonoBehaviour { //класс для постановки целей и подведения итогов
	public Text instr;
	public WindowT wt;
	public GameObject Gun;
	int ButtonOkOr; 
	string Level;
	bool victory;


	// Use this for initialization
	void Start () { 
		ButtonOkOr = 0; //переменная для хранения кол-ва щелчков по кнопке ОК
		Time.timeScale = 0; //останавливаем сцену на время изучения инструкции
		Gun.SetActive (false); //отключаем пистолет, т.к. предыдущая строчка на него не сработала)
		Cursor.lockState = CursorLockMode.None; //делаем видимым курсор
		Cursor.visible = true;
		Level = SceneManager.GetActiveScene().name; //получаем имя загруженной сцены (пригодится)
		GameEvent (Level); //функция сортировки заданий по уровням

	}


	public void TaskOnClick() //кликаем на ОК
	{
		if (ButtonOkOr == 0) { //если в первый раз то...
			wt.Close (); //окно закрывается
			ButtonOkOr = 1; //клик по ОК фиксируется
			Time.timeScale = 1; //запускается сцена
			Gun.SetActive (true); //активируем пистолет
			Cursor.lockState = CursorLockMode.Locked; //прячем курсор
			Cursor.visible = false;
		} 
		else if (ButtonOkOr == 1) { //если по ОК щелчок второй, значит окно выводилось второй раз и оно завершает уровень
			GetComponent<UiController> ().Exit (Level, victory);//вызываем метод смены уровней
		}
	}

	void GameEvent(string i) //сортировщик
	{
		if (i == "1") {  //все для первого уровня
			if (ButtonOkOr == 0) {
				instr.text = "Превый уровень. Твоя задача попасть по голограммам мишеней и летающим шарам," +
				"опередив выстрел последних. Уровень защитывается, если ты не потеряешь все очки жизни " +
				"и попадешь не менее 15 раз.";
			} 
			else if (ButtonOkOr == 1){
				if (this.GetComponent<UiController> ()._hit >= 15) {
					instr.text = "Первый уровень пройден! Твой результат: попаданий " + this.GetComponent<UiController> ()._hit;
					victory = true;
				} 
				else {
					instr.text = "Увы. ты проиграл, но никогда не поздно отыграться! " +
						"Попробуй еще раз. Твой результат: попаданий " + this.GetComponent<UiController> ()._hit;
					victory = false;
				}
			}
		}
		if (i == "2") { //инструкция для вторго уровня
			if (ButtonOkOr == 0) {
				instr.text = "Второй уровень. Твоя задача за одну минуту найти и сбить мишени (банки)";
			} 
			else if (ButtonOkOr == 1){
				instr.text = "Второй уровень пройден! Твой результат: сбитых мишеней " + this.GetComponent<UiController> ()._hit;
				victory = true;
			}
		}

		if (i == "3") { //инструкция для первого уровня
			if (ButtonOkOr == 0) {
				instr.text = "Третий уровень. Твоя задача за одну минуту cбить не менее 15 летающих тарелок";
			} 
			else if (ButtonOkOr == 1){
				if (this.GetComponent<UiController> ()._hit >= 15) {
					instr.text = "Третий уровень пройден! Твой результат: сбитых тарелок " + this.GetComponent<UiController> ()._hit;
					victory = true;
				} 
				else {
					instr.text = "Увы. ты проиграл, но никогда не поздно отыграться! " +
						"Попробуй еще раз. Твой результат: попаданий " + this.GetComponent<UiController> ()._hit;
					victory = false;
				}
			}
		}
	}

	public void EndLevel1() //функция, получающая сообщение, что уровень пора заканчивать (толи время истекло, толи еще что)
	{
		Time.timeScale = 0;//опять тормозим сцену
		Gun.SetActive (false); //пистолет упорно мешает
		Cursor.lockState = CursorLockMode.None; //курсор возвращаем
		Cursor.visible = true;
		wt.Open (); //окно открываем
		GameEvent (Level); //пишем что нужно

	}
	// Update is called once per frame
	void Update () {
	}
}
