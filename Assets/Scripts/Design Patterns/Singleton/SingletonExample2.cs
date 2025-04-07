using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonExample2 : MonoBehaviour
{
    [SerializeField] GameObject persistentObjectPrefab;
    private static bool hasSpawned;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (hasSpawned) return;

        var persistentObject = Instantiate(persistentObjectPrefab);
        DontDestroyOnLoad(persistentObject);
        hasSpawned = true;
    }
}