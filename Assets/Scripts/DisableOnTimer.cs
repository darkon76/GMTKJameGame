using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTimer : MonoBehaviour {


    [SerializeField] float TimeDie = 1;
    [SerializeField] bool MustDestroy = true;
    
    private WaitForSeconds _timer;

    private void OnEnable()
    {
        StartCoroutine( Time() );
    }

    private void OnDisable()
    {
        StopAllCoroutines( );
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds( TimeDie );
        if( MustDestroy )
            Destroy( gameObject );
        else
            gameObject.SetActive( false );
    }
}
