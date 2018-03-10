using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
	public GameObject ufoPrefab;
	public float MinSpawnDelay;
	public float MaxSpawnDelay;
	private GameObject _ufo;
	private float timeTillNextSpawns;
	int index;
	// Use this for initialization
	void Start () {
		timeTillNextSpawns = MinSpawnDelay;

	}

	void Update()
	{
		index = Random.Range (0, 5);
		timeTillNextSpawns -= Time.deltaTime;
		if (timeTillNextSpawns <= 0f)
		{
			StratPrefab (index);
			timeTillNextSpawns = Random.Range(MinSpawnDelay, MaxSpawnDelay);
		}
	}
	void StratPrefab(int i)
	{
		if (i == 0) {
			ufoPrefab.GetComponent<ControlUFO> ().LeftOrRight = false;
			_ufo = Instantiate (ufoPrefab) as GameObject;
			_ufo.transform.position = new Vector3 (-20.7f, -4.45f, -6.24f);
		} 
		else if (i == 1) {
			ufoPrefab.GetComponent<ControlUFO> ().LeftOrRight = true;
			_ufo = Instantiate (ufoPrefab) as GameObject;
			_ufo.transform.position = new Vector3 (30.02f, -3.15f, -6.24f);
		}
		else if (i == 2) {
			ufoPrefab.GetComponent<ControlUFO> ().LeftOrRight = true;
			_ufo = Instantiate (ufoPrefab) as GameObject;
			_ufo.transform.position = new Vector3 (30.02f, -1.77f, -6.24f);
		}
		else if (i == 3) {
			ufoPrefab.GetComponent<ControlUFO> ().LeftOrRight = false;
			_ufo = Instantiate (ufoPrefab) as GameObject;
			_ufo.transform.position = new Vector3 (-20.7f, -0.36f, -6.24f);
		} 
		else if (i == 4) {
			ufoPrefab.GetComponent<ControlUFO> ().LeftOrRight = false;
			_ufo = Instantiate (ufoPrefab) as GameObject;
			_ufo.transform.position = new Vector3 (-20.7f, 1.13f, -6.24f);
		} 
	}

}
