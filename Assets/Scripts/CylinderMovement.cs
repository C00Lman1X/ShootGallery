using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour {

    private bool startMovement;
    public Transform _transform;


    private void FixedUpdate()
    {
        if (!startMovement && _transform != null)
        {
            float x = (0.5f + Random.Range(-0.1f, 0.1f));
            float y = 0.5f;

            Vector3 dir = (_transform.up * y + _transform.right * x) * 5;
            GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
            startMovement = true;

            transform.Rotate(new Vector3(90, 0, 0));

        }
    }

}
