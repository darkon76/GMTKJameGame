using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : SpawnTile
{
    [Range(0,1)]
    public float GapProbability = .25f;


    protected override void Spawn()
    {

        var spawnGap = !lastWasGap &  UnityEngine.Random.value < GapProbability;

        lastWasGap = spawnGap;
        var tileNum = spawnGap? 1:0;
        var tileRef = TilePieces[tileNum];
        var tile = PoolObjectDictionary.Instance.Get(tileRef.gameObject);
#if UNITY_EDITOR
        _spawnPoint = transform.position;
#endif
        _spawnPoint.x = nextSpawnPosition;
        tile.transform.position = _spawnPoint;

        var tilepiece = tile.GetComponent<TilePiece>();
        nextSpawnPosition += tilepiece.Size;
        tile.SetActive( true );
    }
}
