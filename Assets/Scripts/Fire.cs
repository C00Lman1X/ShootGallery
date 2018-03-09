using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public FireGun fg; //переменная для работы с огнем выстрела
                   
    void Start () {
        fg.OffFire(); //выключаем MuzzleFlash
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fg.OnFire(); //включаем MuzzleFlash
        }
        else fg.OffFire(); //выключаем MuzzleFlash
    }
}
