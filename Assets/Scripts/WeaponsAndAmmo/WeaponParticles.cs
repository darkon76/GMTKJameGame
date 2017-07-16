using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticles : MonoBehaviour {
    ParticleSystem _charging;
    ParticleSystem _charged;
    
    
    WeaponHolder _weaponHolder;
    [SerializeField] float _fullParticles;

	// Use this for initialization
	void Awake () {
        var particles  = GetComponentsInChildren<ParticleSystem>();
        _charging = particles[0];
        _charged = particles[1];
        _weaponHolder = GetComponentInParent<WeaponHolder>( );
	}
	
	// Update is called once per frame
	void Update () {
        var per = _weaponHolder.ChargePercentage;
        if( Input.GetMouseButton( 0 ) || per == 1)
        {
            if( _charging.isPlaying )
                _charging.Stop( );
            }
        else
        {
            if(!_charging.isPlaying)
                _charging.Play();
        }

        if(per <.1f)
        {
            if( _charged.isPlaying )
                _charged.Stop( );
        }
        else
        {
            if( !_charged.isPlaying )
                _charged.Play( );
        }

        var emission = _charged.emission;
        emission.rateOverTime = _fullParticles * per * per;

    }
	
}
