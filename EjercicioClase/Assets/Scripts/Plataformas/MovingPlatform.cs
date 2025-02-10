using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform player;
    private bool isPlayerOnMovingPlatform;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnMovingPlatform) 
        {
            player.SetParent(this.transform);
        }
        else
        {
            player.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            if (other.transform == player)
        {
            isPlayerOnMovingPlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform == player)
        {
            isPlayerOnMovingPlatform = false;
        }
    }
}
