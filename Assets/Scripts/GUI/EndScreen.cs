using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour {




	// Use this for initialization
	void Awake () {

        var Player = FindObjectOfType<MainCharacterController>();
        Player.OnPlayerDead += OnPlayerDead;

        var btns = GetComponentsInChildren<Button>();
        btns[0].onClick.AddListener( RestartScene );
        btns[1].onClick.AddListener( () => PlayerPrefs.DeleteKey( "TutorialPassed" ) );
        btns[1].onClick.AddListener( RestartScene );
    }

    void OnPlayerDead()
    {
        gameObject.SetActive( true );
    }

    void RestartScene()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

}
