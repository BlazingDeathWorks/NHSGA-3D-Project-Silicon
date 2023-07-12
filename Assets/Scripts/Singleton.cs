using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T _instance { private set;  get; }
    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }
}

