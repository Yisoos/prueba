using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    private static MusicSingleton instance; // Make this static to share across all instances

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Ensure this instance persists
        }
        else
        {
            Destroy(this.gameObject); // Destroy duplicate instances
        }
    }
}
