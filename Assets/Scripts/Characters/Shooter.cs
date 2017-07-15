using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject Projectile;
    public Transform Nozzle;
	// Use this for initialization
	public void Shoot()
    {
        var projectile = PoolObjectDictionary.Instance.Get(Projectile);
        projectile.transform.SetPositionAndRotation( Nozzle.transform.position, Nozzle.transform.rotation );
        projectile.SetActive( true );
    }
}
