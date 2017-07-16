using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnable : MonoBehaviour {

    [SerializeField] GameObject _enableObject;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        _enableObject.SetActive( true );
        PlayerPrefs.SetInt( "TutorialPassed", 1 );
    }
}
