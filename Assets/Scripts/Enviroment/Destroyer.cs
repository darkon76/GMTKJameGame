using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        var tilePiece = other.GetComponentInParent<PoolObject>();
        if(tilePiece)
            tilePiece.gameObject.SetActive( false );
    }
}
