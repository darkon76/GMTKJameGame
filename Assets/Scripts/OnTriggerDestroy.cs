using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy: MonoBehaviour {

    [SerializeField] GameObject _enableObject;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        Destroy( _enableObject );
    }
}
