using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    public void PauseGame(Animator animator)
    {
        //Time.timeScale = 0;
        animator.SetBool("gamePaused",true);
    }
    public void UnpauseGame(Animator animator)
    {
        //Time.timeScale = 0;
        animator.SetBool("gamePaused", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
