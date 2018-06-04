using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lamp : MonoBehaviour {
	// Use this for initialization
	int control = 0, number, level = 1, col_Lamp = 4;
	public int numMas = 0;
	public GameObject perfabLamp;
	public UnityEvent EndLevel;
	public UiController iuc;
	int[] mas = new int[7];
	struct lamp{
		public GameObject Lamp;
		public int variant;
	}
	lamp[] ls = new lamp[7];
	public GameObject gun;
	void Start () {
		numMas = 0;
		gun.SetActive (false);
		Placing ();
		Light ();
	}


	void Placing(){
		lamp lm = new lamp(); bool d = false;
		float X = -3.15f, Z;
		int variant = 0; int i = 0;
		while (i < col_Lamp) {
			d = false;
			variant = Random.Range (1, 6);
			if (ControlRepetition (variant) != false) {
				if (variant == 1) {
					lm.Lamp = Instantiate (perfabLamp) as GameObject;
					lm.Lamp.transform.position = new Vector3 (-3.54f, -2.03f, -13.17f);
					d = true;
				} else if (variant == 2) {
					lm.Lamp = Instantiate (perfabLamp) as GameObject;
					lm.Lamp.transform.position = new Vector3 (3.28f, -2.03f, -13.17f);
					d = true;
				} else if (variant == 3) {
					lm.Lamp = Instantiate (perfabLamp) as GameObject;
					lm.Lamp.transform.position = new Vector3 (3.574f, -4.97f, -12.505f);
					d = true;
				} else if (variant == 4) {
					lm.Lamp = Instantiate (perfabLamp) as GameObject;
					lm.Lamp.transform.position = new Vector3 (-3.75f, -4.97f, -12.505f);
					d = true;
				} else{
					Z = Random.Range (-12.6f, -8.55f);
					lm.Lamp = Instantiate (perfabLamp) as GameObject;
					lm.Lamp.transform.position = new Vector3 (X, -5.36f, Z);
					X += 1.5f;
					if (X > 2.96f) {
						X = -2.15f;
					}
					d = true;

				}
				if (d == true) {
					lm.variant = variant;
					ls [i] = lm;
					i++;
				}
			} 
		}
	}
		

	bool ControlRepetition(int i){
		bool answer = true;
		if (i != 5) {
			for (int j = 0; j < col_Lamp; j++) {
				if (ls [j].variant == i) {
					answer = false;
				}
			}
		}
		return answer;
	}
	void Light() //заполняем массив последовательными номерами ламп(дабы они загорались в случайной последовательности
	{ 
		control = 0;
		
		for (int j = 0; j < col_Lamp; j++) {
			mas[j] = -1;
		}
		int i = 0;
		while(i < col_Lamp) {
			number = Random.Range(0, col_Lamp);
			if (Repeat (number) != true) {
				mas[control] = number;
				control++; i++;
			}
		}
		control = 0;
		MyStart ();
	}
	bool Repeat(int f){ //метод проверки, чтобы номера ламп не повторялись
		bool repeat = false;
		for (int i = 0; i <= control; i++) {
			if (mas[i] == number) {
				repeat = true;
			}
		}
		return repeat;
	}

	void MyStart(){ //вызываем метод OnLight через 1 сек
		Invoke("OnLight", 1f);
	}


	void OnLight(){ //метод включающий лампы
		number = mas [control];
		ls[number].Lamp.GetComponent<HitLamp>().On();
		control++;
		 
		if (control < col_Lamp) {
			MyStart ();
		} else {
			gun.SetActive (true);
		}
	}

	int num = 0;
	public void Hit(){
		number = mas [numMas];
		if (ls [number].Lamp.GetComponent<HitLamp>().OnOrOff == true) {
			iuc.WinScene5 = false;
			EndLevel.Invoke ();
		}
		numMas++;
		if (numMas == col_Lamp) {
			if (level < 3) {
				level++; col_Lamp++;
				DeleteLamp ();
				Invoke("Start", 1f);
			} else {
				iuc.WinScene5 = true;
				EndLevel.Invoke ();
			}

		} 
	}

	void DeleteLamp(){
		for (int i = 0; i < col_Lamp; i++) {
			Destroy (ls [i].Lamp);
		}
	}
	// Update is called once per frame

}
//instansId guid localID
