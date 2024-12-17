using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DatosGlobales", menuName ="Datos/Datos Globales")]
public class DatosGlobales : ScriptableObject
{
    public string nombreJugador;
    public int puntuacion;
    public int dificultad;
    [ContextMenu("Establecer Valores Preestablecidos")]
    public void SetDefaultValues()
    {
        nombreJugador = "";
        puntuacion = 0;
        dificultad = 1;
    }
}
