using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void ExitGame() 
    {
#if UNITY_EDITOR
        // Stops play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Quits the application in a standalone build
            Application.Quit();
#endif
    }
    public void ChangeScene(string sceneName)    
    {
        SceneManager.LoadScene(sceneName);
    }
}
