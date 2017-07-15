using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VersionText : MonoBehaviour {

	
    void Awake()
    {
        Text text = GetComponent<Text>();
        text.text = "V." + Application.version;
        Destroy(this);
    }

}
