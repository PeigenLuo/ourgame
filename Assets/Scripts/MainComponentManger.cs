using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainComponentManger
{
    private static MainComponentManger instance;
    public static void CreateInstance()
    {
        if (instance == null)
        {
            instance = new MainComponentManger();
            GameObject go = GameObject.Find("Bag");
            if (go == null)
            {
                go = new GameObject("Bag");
                instance.main = go;
                // important: make game object persistent:
                Object.DontDestroyOnLoad(go);
            }
            // trigger instantiation of other singletons
            //Component c = BagPanelManage.SharedInstance;
            // ...
        }
    }

    GameObject main;

    public static MainComponentManger SharedInstance
    {
        get
        {
            if (instance == null)
            {
                CreateInstance();
            }
            return instance;
        }
    }

    public static T AddMainComponent<T>() where T : UnityEngine.Component
    {
        T t = SharedInstance.main.GetComponent<T>();
        if (t != null)
        {
            return t;
        }
        return SharedInstance.main.AddComponent<T>();
    }
}