using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PushingObject : MonoBehaviour
{
    public PlayerMovementController playerMovementController;
    public PositionConstraint positionConstraint;

    public void OnCollisionStay(Collision collision)
    {
        PlayerMovementController playerController = collision.gameObject.GetComponent<PlayerMovementController>();

        if (playerController != null && playerController == playerMovementController)
        {
            if (playerController.isPushing)
            {
                // Reset the offset before enabling the constraint
                if (!positionConstraint.constraintActive)
                {
                    //positionConstraint.translationOffset = Vector3.zero;
                    positionConstraint.constraintActive = true;
                }
            }
            else
            {
                positionConstraint.constraintActive = false;
            }
        }
    }
    private void Update()
    {
        if (!playerMovementController.isPushing) 
        {
            positionConstraint.constraintActive = false;
        }
    }
}
