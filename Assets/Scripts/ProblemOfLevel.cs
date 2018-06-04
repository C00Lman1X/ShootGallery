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
	int index;

	// Use this for initialization
	void Start () { 
		index = PlayerPrefs.GetInt ("continue"); //проверяем игра новая или надо загружать
		Level = SceneManager.GetActiveScene().name; //получаем имя загруженной сцены (пригодится)
		ButtonOkOr = 0; //переменная для хранения кол-ва щелчков по кнопке ОК
		if (index == 1) { //если index == 1 то загружается сохранение
			wt.Close (); //закрываем диалоговое окно
			PlayerPrefs.DeleteKey ("continue");//удаляем временный ключ из реестра
			GetComponent<Menu>().Load ();//вызываем метод загрузки сохранений
			TaskOnClick (); //работаем далее
		}
		else{
			Time.timeScale = 0; //останавливаем сцену на время изучения инструкции
			Gun.SetActive (false); //отключаем пистолет, т.к. предыдущая строчка на него не сработала)
			Cursor.lockState = CursorLockMode.None; //делаем видимым курсор
			Cursor.visible = true;
			GameEvent (Level); //функция сортировки заданий по уровням
		}

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
				instr.text = "Превый уровень!\n Твоя задача попасть по голограммам мишеней и летающим шарам," +
				"опередив выстрел последних. Уровень защитывается, если ты не потеряешь все очки жизни " +
				"и попадешь не менее 15 раз.";
			} 
			else if (ButtonOkOr == 1){
				if (this.GetComponent<UiController> ()._hit >= 15) {
					instr.text = "Первый уровень пройден!\n Твой результат: попаданий " + this.GetComponent<UiController> ()._hit;
					victory = true;
				} 
				else {
					instr.text = "Увы, ты проиграл, но никогда не поздно отыграться! " +
						"Попробуй еще раз. Твой результат: попаданий " + this.GetComponent<UiController> ()._hit;
					victory = false;
				}
			}
		}
		if (i == "2") { //инструкция для вторго уровня
			if (ButtonOkOr == 0) {
				instr.text = "Второй уровень!\n Твоя задача за 30 секунд найти и сбить не менее 14 мишеней (бочки)";
			} 
			else if (ButtonOkOr == 1){
				if (this.GetComponent<UiController> ()._hit >= 14) {
                    instr.text = "Второй уровень пройден!\n Твой результат: " + this.GetComponent<UiController>()._hit + " уничтоженных бочек";
                    victory = true;
				} 
				else {
                    instr.text = "Увы, ты проиграл, но никогда не поздно отыграться! " +
                        "Попробуй еще раз. Твой результат: " + this.GetComponent<UiController>()._hit + " попаданий";

                    victory = false;
				}
			}
		}

		if (i == "3") { //инструкция для первого уровня
			if (ButtonOkOr == 0) {
				instr.text = "Третий уровень!\n Твоя задача за одну минуту cбить не менее 10 летающих тарелок. \n" +
					"Осторожнее с низколетящими тарелками. Ты находишся в полезрения их приборов, а значит тебя постараются подстрелить!";
			} 
			else if (ButtonOkOr == 1){
				if (this.GetComponent<UiController> ()._hit >= 10) {
					instr.text = "Третий уровень пройден! Твой результат: сбитых тарелок " + this.GetComponent<UiController> ()._hit;
					victory = true;
				} 
				else {
					instr.text = "Увы, ты проиграл, но никогда не поздно отыграться! " +
						"Попробуй еще раз. Твой результат: попаданий " + this.GetComponent<UiController> ()._hit;
					victory = false;
				}
			}
		}

        if (i == "4")
        { //инструкция для первого уровня
            if (ButtonOkOr == 0)
            {
                instr.text = "Четвертый уровень!\n Твоя задача за одну минуту найти и сбить не менее 15 бочек.\n" +
                     "Постарайся следить куда отлетают бочки.\n\n PS: синие бочки нас к победе не приведут.";
            }
            else if (ButtonOkOr == 1)
            {
                if (this.GetComponent<UiController>()._hit >= 15)
                {
                    instr.text = "Четвертый уровень пройден! Твой результат: " + this.GetComponent<UiController>()._hit + " уничтоженных бочек";
                    victory = true;
                }
                else
                {
                    instr.text = "Увы, ты проиграл, но никогда не поздно отыграться! " +
                        "Попробуй еще раз. Твой результат: " + this.GetComponent<UiController>()._hit + " попаданий";
                    victory = false;
                }
            }
        }

		if (i == "5")
		{ //инструкция для первого уровня
			if (ButtonOkOr == 0)
			{
				instr.text = "Пятый уровень!\n Твоя задача за одну минуту вывести робошар к выходу из лабиринта." +
					"Стреляй по шару для того, чтобы развернуть его.";
			}
			else if (ButtonOkOr == 1)
			{
				if (this.GetComponent<UiController>().WinScene5 == true)
				{
					instr.text = "Пятый уровень пройден!\n Ты ловко выпутался.";
					victory = true;
				}
				else
				{
					instr.text = "Увы,  ты проиграл, время истекло, но никогда не поздно отыграться! " +
						"Попробуй еще раз.";
					victory = false;
				}
			}
		}

        if (i == "6")
        { //инструкция для шестого уровня
            if (ButtonOkOr == 0)
            {
                instr.text = "Шестой уровень!\n Твоя задача точно повторить последовательность в которой зажглись фонари.";
            }
            else if (ButtonOkOr == 1)
            {
                if (this.GetComponent<UiController>().WinScene5 == true)
                {
                    instr.text = "Шестой уровень пройден!\n У тебя прекрасная память!.";
                    victory = true;
                }
                else
                {
                    instr.text = "Увы,  ты проиграл, но никогда не поздно отыграться! " +
                        "Попробуй еще раз.";
                    victory = false;
                }
            }
        }

        if (i == "7")
        { //инструкция для первого уровня
            if (ButtonOkOr == 0)
            {
                instr.text = "Пятный уровень!\n Твоя задача за одну минуту найти и уничтожить не менее 15 танков.\n";
            }
            else if (ButtonOkOr == 1)
            {
                if (this.GetComponent<UiController>()._hit >= 15)
                {
                    instr.text = "Шестой уровень пройден! Твой результат: " + this.GetComponent<UiController>()._hit + " уничтоженных танков";
                    victory = true;
                }
                else
                {
                    instr.text = "Увы, ты проиграл, но никогда не поздно отыграться! " +
                        "Попробуй еще раз. Твой результат: " + this.GetComponent<UiController>()._hit + " попаданий";
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
