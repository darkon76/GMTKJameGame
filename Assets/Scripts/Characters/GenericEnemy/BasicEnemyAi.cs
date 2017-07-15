using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent ))]
public class BasicEnemyAi : MonoBehaviour {

    [SerializeField]    private NavMeshAgent _agent;
    [SerializeField]    private Transform _target;

	// Use this for initialization
	void Awake ()
    {
        _agent = GetComponent<NavMeshAgent>( );
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_target)
            _agent.destination = _target.position;
	}
}
