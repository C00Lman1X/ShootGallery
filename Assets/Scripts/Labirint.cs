using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour {
	
	public GameObject [] wall = new GameObject[35]; //массив для хранения ссылок на стены в лабиринте
	//массив для расчета пути 
	int[,] massiv = {{-1, 1, 0, 2, 0, 3, 0, 4, 0, 5}, {6, -1, 7, -1, 8, -1, 9, -1, 10, -1}, {0, 11, 0, 12, 0, 13, 0, 14, 0, 15}, {16, -1, 17, -1, 18, -1, 19, -1, 20, -1}, {0, 21, 0, 22, 0, 23, 0, 24, 0, 25}, {26, -1, 27, -1, 28, -1, 29, -1, 30, -1}, {0, 31, 0, 32, 0, 33, 0, 34, 0, 35}};

	// Use this for initialization
	void Start () {
		int choice = 0, i = 0, j = 0;

		//задаем начальную точку входа в лабиринт
		choice = Random.Range (1, 3);
		if (choice == 1) {
			i = 0; j = 1; 
			Work (i, j); // удаляем стену со сцены
		} 
		else if (choice == 2) {
			i = 1; j = 0;
			Work (i, j);
		}
		Way(i, j, choice);
		if (wall [33] != null) {
			Destroy (wall [33]);
		}
		if (wall [34] != null) {
			Destroy (wall [34]);
		}
	}

	void Work(int i, int j) //метод для поиска и удаления стен
	{
		int choice;
		choice = massiv [i, j];
		massiv [i, j] = -1;
		if (choice > 0) {
			for (int l = 0; l < 35; l++) {
				if (wall [i] != null) {
					if (choice.ToString () == wall [l].name) {
						Destroy (wall [l]);
					}
				}
			}
		} 
	}

	void Way(int i, int j, int choice){
		//цикл для расчета пути
		while (choice != 8) {
			if (i == 6) {  // когда мы дошли до нижней стенки
				j++;
				Work (i, j);
			}
			choice = Step (i, j); // выбираем в каком направлении двигаться
			if (choice == 1) { //можно двигаться только влево
				j--;
				Work (i, j);
			} else if (choice == 2) {//можно двигаться только вправо
				j++;
				Work (i, j);
			} else if (choice == 3) {//можно двигаться только вниз
				i++;
				Work (i, j);
			} else if (choice == 4) { //можно двигаться налево или направо
				choice = Random.Range (1, 3);
				if (choice == 1) {
					j--;
					Work (i, j);
				} else {
					j++;
					Work (i, j);
				}
			} else if (choice == 5) { //можно двигаться налево или вниз
				choice = Random.Range (1, 3);
				if (choice == 1) {
					j--;
					Work (i, j);
				} else {
					i++;
					Work (i, j);
				}
			} else if (choice == 6) { //можно двигаться направо или вниз
				choice = Random.Range (1, 3);
				if (choice == 1) {
					j++;
					Work (i, j);
				} else {
					i++;
					Work (i, j);
				}
			} else if (choice == 7) { // можно двигаться вниз, направо или налево
				choice = Random.Range (1, 4);
				if (choice == 1) {
					j--;
					Work (i, j);
				} else if (choice == 2) {
					j++;
					Work (i, j);
				} else {
					i++;
					Work (i, j);
				} 
			} 
		}
	}
	int Step(int i, int j) // метод для определения в какую сторону двигаться
	{
		if (Left (i, j) & !Right (i, j) & !Bottom (i, j)) {
			return 1;
		} else if (!Left (i, j) && Right (i, j) && !Bottom (i, j)) {
			return 2;
		} else if (!Left (i, j) && !Right (i, j) && Bottom (i, j)) {
			return 3;
		} else if (Left (i, j) && Right (i, j) && !Bottom (i, j)) {
			return 4;
		} else if (Left (i, j) && !Right (i, j) && Bottom (i, j)) {
			return 5;
		} else if (!Left (i, j) && Right (i, j) && Bottom (i, j)) {
			return 6;
		} else if (Left (i, j) && Right (i, j) && Bottom (i, j)) {
			return 7;
		} else
			return 8;
	}

	bool Left(int i, int j) //определяем, можно ли двигаться налево
	{
		bool flag = false;
		if (j > 0) {
			j--;
			if (massiv [i, j] != -1) {
				flag = true;
			}
		}
		return flag;
	}

	bool Right(int i, int j) //определяем, можно ли двигаться направо
	{
		bool flag = false;
		if (j < 4) {
			j++;
			if (massiv [i, j] != -1) {
				if (massiv [i, j] == 5) {
					flag = false;
				} else if (massiv [i, j] == 15) {
					flag = false;
				} else if (massiv [i, j] == 25) {
					flag = false;
				} else {
					flag = true;
				}
			}
		} 
		return flag;
	}

	bool Bottom(int i, int j) //определяем, можно ли двигаться вниз
	{
		bool flag = false;
		if (i < 6) {
			i++;
			if (massiv [i, j] != -1)
				flag = true;

		}
		return flag;
	}


	// Update is called once per frame

}
