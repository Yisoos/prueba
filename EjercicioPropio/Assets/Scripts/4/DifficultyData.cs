using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

[CreateAssetMenu(fileName = "DatosGlobales", menuName = "Datos/Dificultad", order = 1)]
public class DifficultyData : ScriptableObject
{
    public Difficulties[] difficulties;
    public Difficulties currentDifficulty;
    public int currentScore;
    public List<int> leaderBoard;
    public List<string> leaderBoardDifficulty;
}
