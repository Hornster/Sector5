using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Singleton<T> : MonoBehaviour where T: Singleton<T>
//{
//    private static T instance;

//    public static T Instance
//    {
//        get
//        {
//            if(instance == null)
//            {
//                Debug.LogError(typeof(T) + " is NULL.");
//            }

//            return instance;
//        }
//    }

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = (T)this;
//        }
//        else if (instance != this)
//        {
//            Destroy(gameObject.GetComponent(Instance.GetType()));
//        }

//        DontDestroyOnLoad(gameObject);
//    }
//}