using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimation : MonoBehaviour
{
    public Animator animationControlled;

    private Transform player;
    private Animator animator;
    private bool isAnimationPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.transform == player)
        {
            isAnimationPaused = !isAnimationPaused;
            animator.SetBool("Pressed", true);
            animationControlled.speed = isAnimationPaused ? 0 : 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == player)
        {
            animator.SetBool("Pressed", false);
        }
    }
}
