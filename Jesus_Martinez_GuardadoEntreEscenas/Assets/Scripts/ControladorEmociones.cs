using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControladorEmociones : MonoBehaviour
{
    public EstadoEmocional estadoEmocional;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            estadoEmocional.emocionActual = "feliz";
            Debug.Log($"Se ha cambiado a la emoción: {estadoEmocional.emocionActual}");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            estadoEmocional.emocionActual = "triste";
            Debug.Log($"Se ha cambiado a la emoción: {estadoEmocional.emocionActual}");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            estadoEmocional.emocionActual = "enfadado";
            Debug.Log($"Se ha cambiado a la emoción: {estadoEmocional.emocionActual}");
        }
    }
}
