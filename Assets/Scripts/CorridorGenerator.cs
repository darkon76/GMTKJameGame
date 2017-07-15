using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : MonoBehaviour {


    [SerializeField] GameObject Destroyer;
    [SerializeField] int tileWidht = 6;
    [SerializeField] int tileLenght = 18;
    


    [SerializeField] List<TilePiece> TileList = new List<TilePiece>();
    [SerializeField] List<TilePiece> WallList = new List<TilePiece>();


    [SerializeField] Queue<GameObject> UpperWall = new Queue<GameObject>();


    [SerializeField]
    float wallStart = -10;

    [SerializeField]
    float wallDistance = 10;


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
