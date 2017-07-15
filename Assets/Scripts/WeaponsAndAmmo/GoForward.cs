using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GoForward : MonoBehaviour {


    public  float Force = 2000;
    Rigidbody _rigidBody;

	// Use this for initialization
	void Awake () {
        _rigidBody = GetComponent<Rigidbody>( );
	}

    private void OnEnable()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce( transform.forward * Force, ForceMode.Force );
    }
    private void OnDisable()
    {
        _rigidBody.velocity = Vector3.zero;
    }
}
