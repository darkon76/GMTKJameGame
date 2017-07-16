using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    WeaponHolder _weaponHolder;
    public ParticleSystem _chargeParticles; 
    private void Awake()
    {
        _weaponHolder = GetComponentInChildren<WeaponHolder>( );
    }


    // Update is called once per frame
    void Update ()
    {
        if( Input.GetMouseButton( 0 ) )
        {
            _weaponHolder.TryShoot( );
        }
	}
}
