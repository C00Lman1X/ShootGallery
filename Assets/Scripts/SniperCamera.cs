using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCamera : MonoBehaviour {

    public Transform CameraSniper;

    public void OnCamera()
    {
        gameObject.SetActive(true); //включаем CameraSniper
    }

    public void OffCamera()
    {
        gameObject.SetActive(false); //выключаем CameraSniper
    }
}
