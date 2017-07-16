using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour {


    public event System.Action OnPlayerDead;

    [SerializeField] float TutorialPassedX = 60;

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag( "Player" ) )
        {
            if( OnPlayerDead != null )
                OnPlayerDead.Invoke( );
            gameObject.SetActive( false );
        }

        if( collision.gameObject.CompareTag( "Respawn" ) )
        {
            if( OnPlayerDead != null )
                OnPlayerDead.Invoke( );
            gameObject.SetActive( false );
        }
    }

    private void Start()
    {
        int tutorialPassed = PlayerPrefs.GetInt("TutorialPassed", 0);
        if( tutorialPassed == 0 )
            return;
        var pos = transform.position;
        pos.x = TutorialPassedX;
        transform.position = pos;

    }
}
