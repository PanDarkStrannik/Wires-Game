using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Singleton<T> : Singleton where T : MonoBehaviour
{
    private static T _instance;

    private static readonly object Lock = new object();

    private bool _persistent = true;

    public static T Instance
    {
        get
        {
            if (Quiting)
            {
                Debug.LogWarning($"{nameof(Singleton)}<{typeof(T)}> не может быть вызван, так как приложение закрывается");
                return null;
            }
            lock(Lock)
            {
                if (_instance != null)
                    return _instance;
                var instances = FindObjectsOfType<T>();
                var count = instances.Length;
                if (count > 0)
                {
                    if (count == 1)
                        return _instance = instances[0];
                    Debug.LogWarning($"{nameof(Singleton)}<{typeof(T)}> должно быть не больше одного синглтона на сцене!");
                    for(var i =1; i<instances.Length; i++)
                    {
                        Destroy(instances[i]);
                    }
                    return _instance = instances[0];
                }

                Debug.Log($"{nameof(Singleton)}<{typeof(T)}> не существует и будет создан!");
                return _instance = new GameObject($"({nameof(Singleton)}){typeof(T)}").AddComponent<T>();
                        
            }
        }
    }
    private void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(gameObject);
        OnAwake();
    }

    protected virtual void OnAwake() { }
}



public abstract class Singleton : MonoBehaviour
{
   public static bool Quiting { get; private set; }

    private void OnApplicationQuit()
    {
        Quiting = true;
    }
}
