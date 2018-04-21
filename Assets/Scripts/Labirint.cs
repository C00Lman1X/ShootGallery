using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour {
	
	public GameObject wall; //массив для хранения ссылок на стены в лабиринте
	int [,] massiv = new int[11,14];
	int [] work = new int[14];

	void Start () {
		int number = 1;
		for (int i = 0; i < 14; i++) {
			work [i] = number;
			number++;
		}
		number = 1;
		for (int i = 0; i < 11; i++) {
			for (int j = 0; j < 14; j++) {
				if ((i % 2) == 0) {
					if (j == 13) {
						massiv [i, j] = 0;
					} else {
						massiv [i, j] = number;
						number++;
					}
				} else {
					massiv [i, j] = number;
					number++;
				}
			}
		}
		for (int i = 0; i < 10; i+= 2) {
			VerticalWalls (i);
			HorizontalWalls (i);
			Line ();
		}
		//VerticalWalls (8);
		//HorizontalWalls (8);
		End (10);
	}

	void HorizontalWalls(int i)
	{
		int next, start = 0, end = work[13];
		for (int j = 0; j < 13; j++) {
			next = j + 1;
			if (work [j] != work [next]) {
				Multitude (start, i, j);
				start = next;
			} 
		}
		if (work [12] != end) {
			DeleteWall (++i, 13);
		}

	}

	void Multitude(int start, int i, int j)
	{
		i++; 
		if (start == j) {
			DeleteWall (i, j);
		} else {
			for (int g = start; g <= j; g++) {
				if (Random.Range (1, 3) < 2) {
					DeleteWall (i, g);
				} else {
					work [g] = 0;
				}
			}
		}

		int contrl_false = 0, count = 0;
		for (int g = start; g <= j; g++) {
			if (work [g] < 0) {
				contrl_false++; count++;
			}
		}
		if (contrl_false == count) {
			DeleteWall(i, Random.Range(start, ++j));
		}
	}
	void VerticalWalls(int i)
	{
		int next;
		for (int j = 0; j < 13; j++) {
			next = j + 1;
			if (work [j] != work [next]) {
				if (Random.Range (1, 3) < 2) {
					DeleteWall (i, j);
					work [next] = work [j];
				} 
			} 
		}
	}

	void Line()
	{
		int number = 1;
		for (int j = 0; j < 14; j++) {
			if (work [j] == 0) {
				work [j] = number;
				number++;
			} else {
				number = work [j];
				number++;
			}
		}
	}
	void End(int i)
	{
		int next = 0;
		for (int j = 0; j < 13; j++) {
			next = j + 1;
			if (work [j] != work [next]) {
				DeleteWall (i, j);
				work [next] = work [j];
			}
		}
	}
	void DeleteWall(int i, int j) //метод для поиска и удаления стен
	{
		wall = GameObject.Find(massiv[i,j].ToString());
		if (wall != null) {
			Destroy (wall );
		}
	}


}
