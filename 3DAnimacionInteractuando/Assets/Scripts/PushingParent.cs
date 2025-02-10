using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PushingParent : MonoBehaviour
{
    public PlayerMovementController playerMovementController;

    public void PushObject(PlayerMovementController playerController, Transform objectToParent)
    {
        if (playerController.isPushing)
        {
            this.transform.SetParent(objectToParent, true);
        }
        else
        {
            this.transform.SetParent(null);
        }
    }
    private void Update()
    {
        //if (!playerMovementController.isPushing)
       // {
        //    this.transform.SetParent(null);
        //}
    }
}
