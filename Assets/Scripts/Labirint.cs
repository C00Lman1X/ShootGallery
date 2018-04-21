﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour {
	//Используется алгоритм генерации лабиринта Эллера
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
		VerticalWalls (10);
		End ();
	}

	void HorizontalWalls(int i)
	{
		int top = i, next;
		i++;
		for (int j = 0; j < 14; j++) {
			if (massiv [top, j] < 0) {
				if (Random.Range (1, 3) < 2) {
					DeleteWall (i, j);
				} else {
					work [j] = 0;
				}
			} else {
				DeleteWall (i, j);
			}
		}

	}
		
	void VerticalWalls(int i)
	{
		
		int next; int h = 1;
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
	void End()
	{
		int wall = 0;
		for (int j = 0; j < 14; j++) {
			for (int i = 0; i < 11; i+= 2) {
				if (i == 10) {
					if (wall > 3) {
						DeleteWall (i, j);
						//DeleteSuperfluousWalls (i, j, wall);
						wall = 0;
					}
				}
				if (massiv [i, j] > -1) {
					wall++;
				} else if(massiv[i, j] == -1){
					if (wall > 3) {
						int i1 = i - 1;
						DeleteWall (i1, j);
						//DeleteSuperfluousWalls (i1, j, wall);
						wall = 0;
					} else {
						wall = 0;
					}
				}
			}
			wall = 0;
		}
	}

	void DeleteSuperfluousWalls(int i, int j, int wall)
	{
		int contrl = 0;
		int h = Random.Range (1, ++wall);
		while (contrl > wall) {
			contrl++;
			if (contrl == h) {
				DeleteWall (i, j);
			}
			i -= 2;
		}
	}
	void DeleteWall(int i, int j) //метод для поиска и удаления стен
	{
		wall = GameObject.Find(massiv[i,j].ToString());
		if (wall != null) {
			Destroy (wall );
			massiv [i, j] = -1;
		}
	}


}
