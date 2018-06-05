using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ReactiveTarget : MonoBehaviour {
	public ParticleSystem part;

    private bool dead = false;
    public bool IsDead() { return dead; }

	public void ReactToHit ()
	{
		StartCoroutine (Die ());
	}

	private IEnumerator Die ()
	{
        dead = true;

        if (part != null)
            part.Play();
        else
		{
			transform.DOShakePosition(0.5f);
		}

		yield return new WaitForSeconds (0.5f);
		if (transform.parent)
			Destroy (transform.parent.gameObject);
		else
			Destroy (gameObject);

	}
    
	void Start () {
        if (part != null)
		    part.Stop ();
	}
	
	void Update () {
		
	}
}
