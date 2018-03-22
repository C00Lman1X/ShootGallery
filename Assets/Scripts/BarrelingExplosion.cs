using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelingExplosion : MonoBehaviour {

    public ParticleSystem part;

    public void ReactToHitBarrelExplosion() //реакция на удар
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        if (part != null)
            part.Play();

        else
            yield return new WaitForSeconds(0.5f);

        Boom.Instance.Explosion(transform.position);
        Destroy(this.gameObject);
    }

    void Start()
    {
        if (part != null)
            part.Stop();
    }
}
