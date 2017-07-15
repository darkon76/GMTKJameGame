using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool isQuitting = false;

    private static T _instance;
    public static T Instance
    {
        get
        {
            if (isQuitting)
            {
                return null;
            }
            if (_instance == null)
            {
                var singleton = new GameObject(typeof(T).ToString());
                _instance = singleton.AddComponent<T>();
                DontDestroyOnLoad( singleton );
            }
            return _instance;
        }
    }

    virtual protected void Awake()
    {
        if( _instance == null )
        {
            _instance = this as T;
            DontDestroyOnLoad( this );
        }

    }

    virtual protected void OnDestroy()
    {
        isQuitting = true;
    }
}