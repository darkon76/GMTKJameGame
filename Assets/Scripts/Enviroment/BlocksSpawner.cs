using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour {


    [SerializeField] private List<TilePiece> _tiles;
    [SerializeField] public int MaxBlockersPerColumn = 3;


    [Range(0,100f)]
    public float BoxTileProbability = 5f;

    [Range(0,100f)]
    public float BlockerTileProbability = 5f;

    [MinMaxRange(0,100f)]
    public RangedFloat _powerUpSpawnProbability = new RangedFloat(0,10f);

    [SerializeField] private bool[] _lastBoxes = new bool[6];

    [SerializeField] private float _boxSeparation = 2;

    [SerializeField] private float _nextBoxPosition = 0;

    private Vector3 _currentPosition;

    protected void SpawnColumn()
    {
        _nextBoxPosition += _boxSeparation;
        int offset = UnityEngine.Random.Range(0,6);

        var blockersSpawned = 0;
        for(var i =0; i<6; i++)
        {
            var slot = (offset + i) % 6;
            var random = UnityEngine.Random.value * 100;

            if( (_lastBoxes[slot] == false) && (MaxBlockersPerColumn > blockersSpawned) && (BlockerTileProbability > random))
            {
                SpawnTile( 1, i );
                _lastBoxes[slot] = true;
                blockersSpawned++;
                continue;
            }
            _lastBoxes[slot] = false;
            if( BoxTileProbability > random )
            {
                SpawnTile( 0, slot );
            }
        }
    }

    private void SpawnTile(int type, int row)
    {
        var tileObj = PoolObjectDictionary.Instance.Get<TilePiece>(_tiles[type]);
        _currentPosition.z = transform.position.z + ( 2 * row);
        UnityEngine.Debug.Log( "Offset " + row );
        tileObj.transform.position = _currentPosition;
        tileObj.gameObject.SetActive( true );
    }

    private void Start()
    {
        _nextBoxPosition = transform.position.x + _boxSeparation;
    }
    // Update is called once per frame
    void Update () {
        if(transform.position.x - _nextBoxPosition > _boxSeparation  * 3)
            _nextBoxPosition = transform.position.x + _boxSeparation;
        if(transform.position.x >= _nextBoxPosition)
        {
            _currentPosition = transform.position;
            SpawnColumn( );
        }
	}
}
