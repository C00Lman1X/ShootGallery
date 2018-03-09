using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour {

    private bool startMovement; //для проверки действует один раз импульс для гильзы а не постоянно
    public Transform _transform; //переменная для работы с позицией гильзы
    public AudioClip cylindr; //переменная для работы со звуком падающей гильзы


    private void FixedUpdate()
    {
        if (!startMovement && _transform != null) //проверяем есть или нет импульса у гильзы и положение transform отпраили или нет
        {
            float x = (0.5f + Random.Range(-0.1f, 0.1f)); //направление имульса по оси x с рандомным разбросом
            float y = 0.5f; // направление импульса по оси Y

            Vector3 dir = (_transform.up * y + _transform.right * x) * 5; //напрваление вектора умноженное на 5
            GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse); //создаем импульс
            startMovement = true; //отключаем импульс для гильзы

            transform.Rotate(new Vector3(90, 0, 0)); // поворачваем префаб на 90 градусов (расположен перпендикулярно горизонту)

            Destroy(gameObject, 5); // уничтожаем гильзу через 5 секунд
        }
    }

    private void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.name == "floor") //проверка на соприкосновение гильзы с полом
        {
            GetComponent<AudioSource>().PlayOneShot(cylindr); //проигрываем звук упавшей гильзы
        }
    }

}
