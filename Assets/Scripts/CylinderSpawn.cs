using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpawn : MonoBehaviour {

    public Transform cylinder;
    //public CylinderMovement cylinderMovementCS;

    void Start () {
		
	}
	
	void Update () {

       // Vector3 pos = transform.position + transform.forward;
		if(Input.GetMouseButtonDown(0))
        {
            Transform CylinderInstance = (Transform) Instantiate(cylinder, GameObject.Find("CylinderSpawnPoint").transform.position, Quaternion.identity);
            //GameObject cylinder = Instantiate(GameObject.Find("CylinderSpawnPoint"), pos, Quaternion.identity) as GameObject;
            CylinderMovement cylinderMovementCS = cylinder.GetComponent<CylinderMovement>();
            //cylinderMovementCS._transform = transform;
            //cylinder.transform.up = -transform.forward;

            


        }
	}
}
