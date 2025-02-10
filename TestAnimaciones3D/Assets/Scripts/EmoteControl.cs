using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteControl : MonoBehaviour
{
    public Animator animator;
    public void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }
}
