using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour {

    public Vector3 EndPosition;
    
	void Start () {
        transform.DOMove(EndPosition, 1);
    }
	
	void Update () {
		
	}
}
