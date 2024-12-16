using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class TextUpdater
{
    [Header("Name"), Space(5)]
    public TMP_InputField nameInputField;
    public TMP_Text nameText;
    [Space(5)] public string greetingMessage;
    [Header("Difficulty"), Space(5)]
    public TMP_Text difficultyText;
    [Space(5)] public string difficultyPrefix;
    [Header("Score"), Space(5)]
    public TMP_Text scoreText;
    [Space(5)] public string scorePrefix;
    [Space(30)] public DatosGlobales datosGlobales;
    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(datosGlobales.nombreJugador))
        {
            if (nameInputField != null)
            {
                nameInputField.text = datosGlobales.nombreJugador;
            }
            UpdateTextPlayerName();
            UpdateTextDifficulty();
            UpdateTextScore();
        }
    }
    public void UpdateTextPlayerName()
    {
        if (nameText != null)
        {
            nameText.text = greetingMessage.Replace("*",datosGlobales.nombreJugador);
        }
    }

    public void UpdateTextDifficulty()
    {
        if (difficultyText != null)
        {
            difficultyText.text = $"{difficultyPrefix} {datosGlobales.dificultad}";
        }
    }
    public void UpdateTextScore()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{scorePrefix} {datosGlobales.puntuacion} puntos";
        }
    }
}
