using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;
    private void Awake()
    {
        // Find the existing player GameObject by its name
        GameObject player = GameObject.Find("Player");


        // if (player != null)
        // {
        //     // Prevent this GameObject (and its children) from being destroyed between scene loads
        //     DontDestroyOnLoad(gameObject);
        // }

    }
}