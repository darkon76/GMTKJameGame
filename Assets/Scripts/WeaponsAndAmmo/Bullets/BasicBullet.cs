using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

    [SerializeField] AudioObject _audioClip;
    [SerializeField] GameObject _particlesEffect;




    public  float Force = 2000;
    Rigidbody _rigidBody;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>( );
        _rigidBody = GetComponent<Rigidbody>( );
    }

    private void OnCollisionEnter(Collision collision)
    {

        if( _audioSource != null && _audioClip != null )
            _audioClip.Play( _audioSource );
        if(_particlesEffect)
        {
            var particles = PoolObjectDictionary.Instance.Get(_particlesEffect);
            particles.transform.position =  transform.position;
            particles.SetActive( true );
        }
        gameObject.SetActive( false );
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
