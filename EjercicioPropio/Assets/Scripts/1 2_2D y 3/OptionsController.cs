using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public CanvasGroup BrightnessPanel;
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
    public void SetSceneVolume(float volume)
    {
        // Ensure volume is between 0 and 1
        volume = Mathf.Clamp01(volume);

        // Find all AudioSources in the scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        // Adjust their volume
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }

    // Function to control the brightness using a panel's alpha
    public void SetPanelAlpha(float alpha)
    {
        if (BrightnessPanel != null)
        {
            // Ensure alpha is between 0 and 1
            BrightnessPanel.alpha = Mathf.Clamp01(alpha);
        }
    }
}
