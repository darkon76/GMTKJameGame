using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDisplayer : MonoBehaviour {

    private Material mat;
    private int CutOffId;
    private int ChargeColor;

    bool charging = false;
    private void Awake()
    {
        var ren = GetComponent<Renderer>();
        mat = ren.material;
        CutOffId = Shader.PropertyToID( "_Cutoff" );
        ChargeColor = Shader.PropertyToID( "_ChargeColor" );

    }

    public void SetCharge(float cut)
    {
        mat.SetFloat( CutOffId, cut );
    }
    
}
