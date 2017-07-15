using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 _offset;
    public Transform Target;

	// Use this for initialization
	void Awake () {

        _offset = transform.position - Target.position;
        var mainCharacter = FindObjectOfType<MainCharacterController>( );
        Target = mainCharacter.transform;
        mainCharacter.OnPlayerDead += OnPlayerDead;
	}

    // Update is called once per frame
    void Update () {
        var targetPosition = Target.position;
        targetPosition.y = 0;
        transform.position = Vector3.Lerp(transform.position, targetPosition + _offset,Time.deltaTime);
	}
    void OnPlayerDead()
    {
        Destroy( this );
    }
}
