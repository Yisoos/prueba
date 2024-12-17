using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Personalizacion", menuName = "Datos/Personalizacion")]
public class Personalizacion : ScriptableObject
{
    [Space(5)] public string[] difficultyName = new string[3];
    [Space(5)] public BackgroundColorTriggerIndex[] backgroundColors;
}
