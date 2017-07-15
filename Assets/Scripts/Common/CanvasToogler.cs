using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasToogler : MonoBehaviour {
    [SerializeField]    GameObject[] toggleObjects = new GameObject[0];
	void Awake()
	{
        Canvas[] canvas = GetComponentsInChildren<Canvas>(true);

        for(int i=0; i<2; ++i)
        {
            foreach (var can in canvas)
            {
                can.gameObject.SetActive(!can.gameObject.activeSelf);
            }
            

            foreach (var obj in toggleObjects)
            {
                if (obj)
                {
                    obj.SetActive(!obj.activeSelf);
                }
            }
        }
        Destroy(this);
    }
}
