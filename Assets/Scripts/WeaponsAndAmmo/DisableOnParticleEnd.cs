using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnParticleEnd : MonoBehaviour {

    ParticleSystem _particles;
	// Use this for initialization
	void Awake () {
        _particles = GetComponent<ParticleSystem>( );
	}
	
	// Update is called once per frame
	void Update () {

        if( _particles.isStopped )
            gameObject.SetActive( false );
	}
}
