using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingleton
{
    void Init();
}

public abstract class Singleton<T> where T : ISingleton, new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Lazy<T>(true).Value;
                instance.Init();
            }
            return instance;
        }
    }
}
