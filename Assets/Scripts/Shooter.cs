using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject iuc;
    public GameObject dec;

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Physics.Raycast(transform.position, fwd, out hit);
			iuc.GetComponent<UiController>().Str(1); // вызываем метод в UIController для уменьшения числа пуль
            GameObject hitObject = hit.transform.gameObject; //получаем объект попадания
            Contr cn = hitObject.GetComponent<Contr>(); //проверяем наличие метода, если есть дырку от пули не создаем
            if (cn == null)
            {
                GameObject hitObjectP = hitObject;
                hitObjectP = Instantiate(dec); //создаем отверстие от пули и выравниваем его по нормали
                hitObjectP.transform.position = hit.point + hit.normal * 0.01f;
                hitObjectP.transform.rotation = Quaternion.LookRotation(-hit.normal);
                hitObjectP.transform.SetParent(hit.transform); //назначаем родителем объект попадания
            }
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();//проверяем есть ли метод ReactiveTarget
            if (target != null)
            {
                iuc.GetComponent<UiController>().Str(2); // вызываем метод в UIController для увеличения числа попаданий в мишень
                target.ReactToHit();
            }
        }
    }
}
