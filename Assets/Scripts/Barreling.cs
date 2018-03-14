using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barreling : MonoBehaviour {

    public ParticleSystem part;
    public void ReactToHitBarrel() //реакция на удар
    {
        StartCoroutine(Die());
        //Destroy(GameObject.Find("Barrel (1)"), 5);
    }

    private IEnumerator Die()
    {
        if (part != null)
            part.Play();
        else
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

    }

    void Start()
    {
        if (part != null)
            part.Stop();
    }

    void Update()
    {

    }
}
