using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnTile : MonoBehaviour {

    [SerializeField]protected float nextSpawnPosition;
    [SerializeField]protected float spawnDistance;

    [SerializeField] protected List<TilePiece> TilePieces = new List<TilePiece>();

    protected bool lastWasGap = false;
    protected Vector3 _spawnPoint;
    // Use this for initialization
    void Awake () {
        _spawnPoint = transform.position;
	}

    private void Start()
    {
        while( transform.position.x + spawnDistance >= nextSpawnPosition )
        {
            lastWasGap = true;
            Spawn( );
        }
    }

    // Update is called once per frame
    void Update () {
	    if(transform.position.x + spawnDistance >= nextSpawnPosition )
        {
            Spawn( );
        }
	}

    protected abstract void Spawn();
    
}
