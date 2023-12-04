using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 savedPlayerPosition;
    public int stage = 0;
    private GameObject dogKeyToy;
    private TextInteraction dkti;

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
        // Debug.Log("game manager!");
    }

    private void Start()
    {
        // dogKeyToy = GameObject.Find("SPR_keyDogToy_v1001");
        // dkti = dogKeyToy.GetComponent<TextInteraction>();
        // Debug.Log("Found dogKeyToy named: " + dogKeyToy.name + "and accessed component: " + dkti);
    }

    public void SavePlayerPosition(Vector3 position)
    {
        savedPlayerPosition = position;
    }

    public void SetStage(int newStage)
    {
        stage = newStage;
        // if (stage == 2)
        // {
        //     dkti.showKeyToy();
        // }
    }

    public int GetStage()
    {
        return stage;
    }
    
}


