using UnityEngine;

public class SoftSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static bool isApplicationQuitting = false;
    private static T instance;
    public static T Instance
    {
        get
        {
            if(isApplicationQuitting)
            {
                return null;
            }


            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
            }
            return instance;
        }
        
    }

    protected virtual void Awake()
    {
        isApplicationQuitting = false;
        if (Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
    }

    protected virtual void OnDestroy()
    {

        if (instance == this)
        {
            isApplicationQuitting = true;
            instance = null;
        }
    }
}