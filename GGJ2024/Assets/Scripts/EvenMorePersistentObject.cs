using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenMorePersistentObject : MonoBehaviour
{
    public static EvenMorePersistentObject Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
