using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour {

    [SerializeField] WeaponSO _weapon;
    [SerializeField] GameObject _particles;
    private void Awake()
    {
        transform.DOLocalMoveY( 1.2f, 1f ).SetLoops(-1,LoopType.Yoyo).SetEase( Ease.Linear );
        transform.DOLocalRotate(new Vector3(0,10,0),1f).SetLoops( -1, LoopType.Incremental ).SetEase( Ease.Linear );
    }

    private void OnTriggerEnter(Collider other)
    {
        var WeapoonHolder = other.gameObject.GetComponentInChildren<WeaponHolder>();
        if( WeapoonHolder )
        {
            var particles = PoolObjectDictionary.Instance.Get(_particles);
            particles.transform.position = transform.position;
            particles.SetActive( true );
            gameObject.SetActive( false );

        }

    }
}
