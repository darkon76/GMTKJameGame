using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : MonoBehaviour {


    [SerializeField] GameObject Destroyer;


    CharacterStats _character;
    Vector3 _position;
	// Use this for initialization
	void Awake () {
        _character = GameObject.FindObjectOfType<CharacterStats>( );
        _position = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        _position.x = _character.transform.localPosition.x;
        transform.localPosition = _position;
	}

    void SpawnFloor()
    {

    }

    void SpawnWall()
    {

    }
}
