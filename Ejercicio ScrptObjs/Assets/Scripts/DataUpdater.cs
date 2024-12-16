using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataUpdater : MonoBehaviour
{
    public TextUpdater textUpdater;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        if (textUpdater.nameInputField != null)
        {
            textUpdater.nameInputField.text = textUpdater.datosGlobales.nombreJugador;
        }
        CambiarNombreJugador();
        CambiarDificultad(textUpdater.datosGlobales.dificultad);
        CambiarPuntuación(0);
    }
    void Update()
    {
        if (textUpdater.nameInputField !=null)
        {
            if (textUpdater.nameInputField.text != textUpdater.datosGlobales.nombreJugador)
            {
                CambiarNombreJugador();
            }
        }
    }

    public void CambiarNombreJugador() 
    {
        if (textUpdater.nameInputField != null)
        {
            textUpdater.datosGlobales.nombreJugador = textUpdater.nameInputField.text;
        }

        if (textUpdater != null)
        {
            textUpdater.UpdateTextPlayerName();
        }
    }
    public void CambiarDificultad(string nuevaDificultad) 
    {
        textUpdater.datosGlobales.dificultad = nuevaDificultad;
        
        if (textUpdater != null)
        {
            textUpdater.UpdateTextDifficulty();
        }
    }
    public void CambiarPuntuación(int nuevaPuntuacion)
    {
        textUpdater.datosGlobales.puntuacion += nuevaPuntuacion;

        if (textUpdater != null)
        {
            textUpdater.UpdateTextScore();
        }
    }

}
