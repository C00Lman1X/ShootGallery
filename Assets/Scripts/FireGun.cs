using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {

    public Transform MuzzleFlash;

    public void OnFire()
    {
        gameObject.SetActive(true); //включаем MuzzleFlash
    }

    public void OffFire()
    {
        gameObject.SetActive(false); //выключаем MuzzleFlash
    }
}

