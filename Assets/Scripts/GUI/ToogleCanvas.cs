using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleCanvas : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        var canvas = GetComponentsInChildren<Canvas>(true);
        foreach(var canva in canvas)
        {
            canva.gameObject.SetActive( !canva.gameObject.activeSelf );
        }

        foreach( var canva in canvas )
        {
            canva.gameObject.SetActive( !canva.gameObject.activeSelf );
        }


    }


}
