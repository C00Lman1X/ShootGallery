using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper1 : MonoBehaviour {

    public static float mouse; //эту переменную надо использовать в скрипте, который отвечает за вращение головой/камерой с помощью мышки. 
                               //А конкретно тут устанавливается чувствительность для мыши, потому что чем больше зум, тем меньше нужно делать чувствительность

    public Texture2D mainTex; //текстура прицела
    public Texture2D background; //текстура фона прицела
    public float mouseMax = 10; //чувствительность мышки по умолчанию, когда прицел отключен
    public float mouseMin = 0.0001f; //чувствительность мыши когда зум на максимуме
    public Camera _camera; //камера персонажа
    public float maxFOV = 60; //поле зрение по умолчанию, при отключенном зуме. Стандартное значение - 60
    public float minFOV = 1; //минимально допустимое значение поля зрения (максимальный зум)

    private float zoomLevel;
    private bool zoomStart;
    private bool zoom;

    public SniperCamera sc; //переменная для работы с прицелом

    void Start()
    {
        mouse = mouseMax;
        sc.OffCamera();
    }

    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            sc.OnCamera();
            zoom = true;
            if (!zoomStart)
            {
                // стартовые, зум и чувствительность мыши, после включения прицела
                zoomStart = true;
                zoomLevel = maxFOV - 20;
                mouse -= 3.32f;
            }
        }
        else
        {
            sc.OffCamera();
            zoomStart = false;
            zoom = false;
            zoomLevel = maxFOV;
            mouse = mouseMax;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoomLevel > minFOV)
            {
                mouse -= 0.83f; // шаг, регулировки чувствительности мышки
                zoomLevel -= 5; // шаг, регулировки зума
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomLevel < maxFOV)
            {
                mouse += 0.83f;
                zoomLevel += 5;
            }
        }

        mouse = Mathf.Clamp(mouse, mouseMin, mouseMax);
        zoomLevel = Mathf.Clamp(zoomLevel, minFOV, maxFOV);
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, zoomLevel, 10 * Time.deltaTime);
    }


    //В блоке OnGUI мы рисуем наш прицел, если удерживается правая кнопка мыши. 
    //Порядок рисования такой: сначала идет текстура прицела по центру экрана и так как это квадрат то неизбежно 
    //останутся пустые области, далее, текстура фона заполняет область справа от прицела, затем слева.

    void OnGUI()
    {
        if (zoom)
        {
            GUI.depth = 999;
            int hor = Screen.width + 30;
            int ver = Screen.height + 60;
            GUI.DrawTexture(new Rect((hor - ver) / 2, 0, ver, ver), mainTex);
            GUI.DrawTexture(new Rect((hor / 2) + (ver / 2), 0, hor / 2, ver), background);
            GUI.DrawTexture(new Rect(0, 0, (hor / 2) - (ver / 2), ver), background);
        }
    }
}
