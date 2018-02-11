using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {


	public void ReactToHit ()
	{
		StartCoroutine (Die ()); //Die
	}

	private IEnumerator Die ()
	{
		yield return new WaitForSeconds (0.5f); // после попадания ждем 0,5 сек
		Destroy (this.gameObject); // удаляем объект
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
