using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargadorDeEscenas : MonoBehaviour
{
    private Animator transicionAnimacion;

    private void Start()
    {
        transicionAnimacion = GetComponentInChildren<Animator>();
        transicionAnimacion.SetTrigger("FadeIn");
    }

    public void LoadNextScene()
    {
        int siguienteEscena = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadSceneAnimated(siguienteEscena));
    }
    public void LoadPreviousScene()
    {
        int escenePrevia = SceneManager.GetActiveScene().buildIndex - 1;
        StartCoroutine(LoadSceneAnimated(escenePrevia));
    }
    public void LoadLastScene()
    {
        int escenePrevia = SceneManager.sceneCount-1;
        StartCoroutine(LoadSceneAnimated(escenePrevia));
    }
    public void LoadCustomScene(int sceneNumber)
    {
        StartCoroutine(LoadSceneAnimated(sceneNumber));
    }

    private IEnumerator LoadSceneAnimated(int sceneNumber)
    {
        transicionAnimacion.SetTrigger("FadeOut");

        // Espera hasta que termine la animación (ajustar según la duración de tu animación)
        yield return new WaitForSeconds(transicionAnimacion.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(sceneNumber);
    }
}

