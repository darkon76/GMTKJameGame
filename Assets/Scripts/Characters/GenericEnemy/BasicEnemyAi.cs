using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyAi : MonoBehaviour {


    [SerializeField]    private GameObject _deadParticles;
    [SerializeField]    private Transform _target;
    public float Speed = 2;
    private Rigidbody _rigidBody;
    private ZombieHorde _horde;
    private int _health = 3;
    [SerializeField] private int _maxHealth = 3;
    [SerializeField]    private float _chaseTargetDistance = 5;
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] int _levelUpCount = 50;
    int _deadCount = 0;
    
	// Use this for initialization
	void Awake ()
    {
        var player = FindObjectOfType<MainCharacterController>();
        _target = player.transform;
        _rigidBody = GetComponent<Rigidbody>( );
        _horde = FindObjectOfType<ZombieHorde>( );
        _health = _maxHealth;
        _scoreManager = FindObjectOfType<ScoreManager>( );
	}

    private void Update()
    {
        transform.LookAt( _target );
    
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        var distance = _target.position.x -transform.position.x;
       if( _chaseTargetDistance > distance )
        {
            _rigidBody.MovePosition( _rigidBody.position + transform.forward * Speed );
        }
       else
        {
            _rigidBody.MovePosition( _rigidBody.position + Vector3.right * Speed );
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        var bullet = collision.gameObject.GetComponent<BasicBullet>();
        if(bullet)
        {
            _health--;
            if( _health <= 0 )
            {
                if(_deadCount >= _levelUpCount)
                {
                    _deadCount = 0;
                    _maxHealth++;
                }
                var particles = PoolObjectDictionary.Instance.Get(_deadParticles);
                particles.transform.position = transform.position;
                particles.SetActive( true );
                _horde.Recycle( gameObject );
                _health = _maxHealth;

                _scoreManager.OnScoreUp( 10 );

            }
        }
    }
}
