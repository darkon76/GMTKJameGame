using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    Plane _plane;
    Camera _mainCamera;
    // Use this for initialization
	void Awake ()
    {
        _plane = new Plane( Vector3.up, 0 );
        _mainCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = _mainCamera.ScreenPointToRay( Input.mousePosition);
        float enter;
        if( _plane.Raycast( ray, out enter ) )
        {
            Vector3 rayPoint = ray.GetPoint(enter);
            rayPoint.y = transform.position.y;
            transform.LookAt( rayPoint );
        }
    }
}
