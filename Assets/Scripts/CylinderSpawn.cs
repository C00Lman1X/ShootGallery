using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CylinderSpawn : MonoBehaviour {

    public Transform cylinder; //переменная для работы с позиией гильзы
    public AudioClip Fire; //перменная для работы со звуком выстрела
    
	void Update () {

   		if(Input.GetMouseButtonDown(0))
        {
            
            Transform CylinderInstance = (Transform) Instantiate(cylinder, GameObject.Find("CylinderSpawnPoint").transform.position, Quaternion.identity); // находим GameObjec "CylinderSpawnPoint"  с позицией нашей гильзы
            CylinderMovement cylinderMovementCS = cylinder.GetComponent<CylinderMovement>(); //снимаем скрипт с гильзы
            cylinderMovementCS._transform = transform; //передаем позицию нашей гильзы
            //cylinder.transform.up = -transform.forward;

            GetComponent<AudioSource>().PlayOneShot(Fire); //проигрываем звук выстрела
        }
		if (Input.GetMouseButtonDown (1)) {
			if (SceneManager.GetActiveScene ().name == "5") {
				Transform CylinderInstance = (Transform) Instantiate(cylinder, GameObject.Find("CylinderSpawnPoint").transform.position, Quaternion.identity); // находим GameObjec "CylinderSpawnPoint"  с позицией нашей гильзы
				CylinderMovement cylinderMovementCS = cylinder.GetComponent<CylinderMovement>(); //снимаем скрипт с гильзы
				cylinderMovementCS._transform = transform; //передаем позицию нашей гильзы
				//cylinder.transform.up = -transform.forward;

				GetComponent<AudioSource>().PlayOneShot(Fire); //проигрываем звук выстрела
			}
		}
    }
}
