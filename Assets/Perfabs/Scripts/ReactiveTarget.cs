using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ReactiveTarget : MonoBehaviour {
	public ParticleSystem part;
	public void ReactToHit ()
	{
		StartCoroutine (Die ());
	}

	private IEnumerator Die ()
	{
        if (part != null)
            part.Play();
        else
            transform.DOShakePosition(0.5f);
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);

	}
    
	void Start () {
        if (part != null)
		    part.Stop ();
	}
	
	void Update () {
		
	}
}
