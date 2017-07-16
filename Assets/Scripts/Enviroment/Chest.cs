using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    [SerializeField] ParticleSystem _particlesRef;


    private void OnCollisionEnter(Collision collision)
    {
        var bullet = collision.gameObject.GetComponent<BasicBullet>();
        if( bullet )
        {
            if(_particlesRef)
            {
                var particles = PoolObjectDictionary.Instance.Get(_particlesRef.gameObject);
                particles.transform.position = transform.position;
                particles.SetActive( true );
            }
            gameObject.SetActive( false );
        }
    }

}
