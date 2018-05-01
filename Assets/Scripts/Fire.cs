using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour {

    public FireGun fg; //переменная для работы с огнем выстрела
                   
    void Start () {
        fg.OffFire(); //выключаем MuzzleFlash
        //GameObject.Find("MuzzleFlash").SetActive(true);


    }


    void Update()
    {
		if (Input.GetMouseButtonDown (0)) {
			fg.OnFire (); //включаем MuzzleFlash
		} else if (Input.GetMouseButtonDown (1)) {
			if (SceneManager.GetActiveScene ().name == "5") {
				fg.OnFire (); //включаем MuzzleFlash
			}
		}
        else fg.OffFire(); //выключаем MuzzleFlash
    }
}
