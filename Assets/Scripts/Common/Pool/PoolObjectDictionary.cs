using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectDictionary : SoftSingleton<PoolObjectDictionary> 
{
    private readonly Dictionary<GameObject, PoolObjectContainer> _poolDictionary = new Dictionary<GameObject, PoolObjectContainer>();
    [SerializeField] Transform _parent;
    
    public GameObject Get(GameObject template)
    {
        PoolObjectContainer pool;
        if(!_poolDictionary.TryGetValue(template, out pool))
        {
            pool = gameObject.AddComponent<PoolObjectContainer>( );
            var parent = _parent;
            if(parent = null)
                parent = transform;
            pool.Init( template, parent, 1 );
            _poolDictionary.Add( template, pool );
        }
        return pool.Get(); 
    }
}
