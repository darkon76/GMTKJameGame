using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class WeaponHolder : MonoBehaviour {
    [SerializeField] WeaponSO _weapon;

    [SerializeField]
    private GameObject _weaponModel;

    private Rigidbody _rigidbody;
    private AudioSource[] _audioSources;
    private WeaponNozzle[] Nozzles;

    private CharacterStats _stats;
    private int count = 0;
    private Stopwatch _watch = new Stopwatch();

    public float ChargePercentage;

    private ChargeDisplayer _displayer;


    public bool TryShoot()
    {
        if( _weapon == null )
            return false;

        float elapsed = _watch.ElapsedMilliseconds /1000f;
        var attackTime = 1/ (_weapon.AtacksPerSecond * _stats.AttackPerSecondsMultiplier);
        ChargePercentage = Mathf.Min( elapsed, _weapon.MaxChargeTime ) / _weapon.MaxChargeTime;

        var canShoot = elapsed > attackTime;

        canShoot &= _weapon.Projectile != null;
        if( !canShoot )
            return false;


        _watch.Reset( );
        _watch.Start( );
        int charge = 0;
        
        for( var i = _weapon._shootCharges.Count - 1; i >= 0; i-- )
        {
            if( _weapon._shootCharges[i].percentage <= ChargePercentage )
            {
                charge = i;
                break;
            }
        }
        var shootCharge = _weapon._shootCharges[charge];

        var angles = shootCharge.Angles;
        var nozzle = Nozzles[count].transform;
        UnityEngine.Debug.Log( "Shooting " + angles.Count );
        for( var i = 0; i < angles.Count; ++i )
        {
            var projectile = PoolObjectDictionary.Instance.Get(_weapon.Projectile);
            projectile.transform.SetPositionAndRotation( nozzle.position, nozzle.rotation * Quaternion.Euler( 0, angles[i], 0 ) );
            projectile.SetActive( true );
            var bullet = projectile.GetComponent<BasicBullet>();
            if( bullet == null )
                UnityEngine.Debug.Log( "bulleterror" );
        }

        if(shootCharge.Audio )
        {
            shootCharge.Audio.Play( _audioSources[charge] );
        }

        count++;
        count %= Nozzles.Length;
        _rigidbody.velocity += -_rigidbody.transform.forward * shootCharge.ShootForce;
        return true;
    }

    public void Awake()
    {
        _rigidbody = GetComponentInParent<Rigidbody>( );
        _audioSources = GetComponents<AudioSource>( );
        if(_weaponModel == null)
            _weaponModel = Instantiate( _weapon.Model, transform, false );
        Nozzles = _weaponModel.GetComponentsInChildren<WeaponNozzle>( );

        _watch.Start( );
        _stats = GetComponentInParent<CharacterStats>( );
        _displayer = GetComponentInChildren<ChargeDisplayer>( );
    }

    void Update()
    {
        float elapsed = _watch.ElapsedMilliseconds /1000f;
        ChargePercentage = Mathf.Min( elapsed, _weapon.MaxChargeTime ) / _weapon.MaxChargeTime;
        _displayer.SetCharge( ChargePercentage );
    }


}
