using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 savedPlayerPosition;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        Debug.Log("game manager!");
    }

    public void SavePlayerPosition(Vector3 position)
    {
        savedPlayerPosition = position;
    }
    
}


