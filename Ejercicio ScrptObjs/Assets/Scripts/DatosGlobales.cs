using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DatosGlobales", menuName ="Datos/Datos Globales")]
public class DatosGlobales : ScriptableObject
{
    public string nombreJugador;
    public int puntuacion;
    public string dificultad;
    [ContextMenu("Establecer Valores Preestablecidos")]
    public void SetDefaultValues()
    {
        nombreJugador = "";
        puntuacion = 0;
        dificultad = "Normal";
    }
}
