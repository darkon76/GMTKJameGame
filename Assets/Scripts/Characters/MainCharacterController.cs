using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour {


    public event System.Action OnPlayerDead;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            if( OnPlayerDead != null )
                OnPlayerDead.Invoke( );
            gameObject.SetActive( false );
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag( "Player" ) )
        {
            if( OnPlayerDead != null )
                OnPlayerDead.Invoke( );
            gameObject.SetActive( false );
        }
    }
}
