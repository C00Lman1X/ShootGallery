using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
	[SerializeField] private ParticleSystem part; //переменная для системы частиц

	public void ReactToHit ()
	{
		StartCoroutine (Die ()); //Die
	}

	private IEnumerator Die ()
	{
		part.Play (); //запускаем систему частиц после попадания в объект
		yield return new WaitForSeconds (0.5f); // после попадания ждем 0,5 сек
		Destroy (this.gameObject); // удаляем объект

	}

	// Use this for initialization
	void Start () {
		part.Stop (); //останавливаем выполнение системы частиц на время старта
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
