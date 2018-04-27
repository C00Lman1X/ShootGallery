using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labirint : MonoBehaviour {
	//Используется алгоритм генерации лабиринта Эллера
	public GameObject wall1; //массив для хранения ссылок на стены в лабиринте
	public GameObject wall2;
	private GameObject _wall;
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
		Walls ();
		for (int i = 0; i < 10; i+= 2) {
			VerticalWalls (i);
			HorizontalWalls (i);
			Line ();
		}
		VerticalWalls (10);
		End ();
		HorWalls ();
		VertWalls ();
	}

	void HorWalls(){
		float X0 = -25.098f, Y0 = 5.259152f, Z0 = 6.294358f;
		float x = X0, y = 0, z = 0;
		for (int i = 0; i < 11; i+= 2) {
			for (int j = 0; j < 13; j++) {
					if (massiv [i, j] > -1) {
						_wall = Instantiate (wall1) as GameObject;
						_wall.transform.position = new Vector3 (x, Y0, Z0);
						x += 3.996f;
					} else {
						x += 3.996f;
					}
				}
				X0 += 0.018f;
				Y0 += -2.946699f;
				Z0 += -3.55841f;
				x = X0;
			}
	}

	void VertWalls(){
		float X0 = -26.952f, Y0 = 3.732578f, Z0 = 4.677301f;
		float x = X0, y = 0, z = 0;
		for (int i = 1; i < 11; i+=2) {
			for (int j = 0; j < 14; j++) {
				if (massiv [i, j] > -1) {
					_wall = Instantiate (wall2) as GameObject;
					_wall.transform.position = new Vector3 (x, Y0, Z0);
					x += 3.996f;
				} else {
					x += 3.996f;
				}
			}
			X0 += 0.018f;
			Y0 += -2.9466989f;
			Z0 += -3.55841f;
			x = X0;
		}
	}
	void Walls(){
		int middle = Random.Range (0, 11);
		while((middle % 2) == 0){
			middle = Random.Range(0, 11);
		}
		int variant = 0, j = 0, i = 1;
		DeleteWall (middle, 0);
		while(j < 14)  {
			if (middle == 0) {
				++i;
				++middle;
				DeleteWall (middle, j);
			} else if (middle == 10) {
				++i;
				--middle;
				DeleteWall (middle, j);
			} else {
				++i;
				variant = Random.Range (1, 3);
				if (variant > 1) {
					--middle;
					DeleteWall (middle, j);
				} else {
					++middle;
					DeleteWall(middle, j);
				} 
			}
			if (i > 1) {
				i = 0;
				j++;
			}
		}
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
						wall = 0;
					}
				}
				if (massiv [i, j] > -1) {
					wall++;
				} else if(massiv[i, j] == -1){
					if (wall > 3) {
						int i1 = i - 1;
						DeleteWall (i1, j);
						wall = 0;
					} else {
						wall = 0;
					}
				}
			}
			wall = 0;
		}
	}


	void DeleteWall(int i, int j) 
	{
		massiv [i, j] = -1;
		/*wall = GameObject.Find(massiv[i,j].ToString());
		if (wall != null) {
			Destroy (wall );
			massiv [i, j] = -1;
		}*/
	}


}
