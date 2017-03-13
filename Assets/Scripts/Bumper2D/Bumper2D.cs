using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper2D : MonoBehaviour {

    [SerializeField] private float bumpForce;

    void OnCollisionEnter2D(Collision2D col)
    {
        col.rigidbody.AddForce((col.transform.position - transform.position) * bumpForce);
    }
}
