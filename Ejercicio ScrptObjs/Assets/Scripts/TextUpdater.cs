using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Background Color"), Space(5)]
    public Image sceneBackground;
    public BackgroundColorTriggerIndex[] backgroundColors;

    [Space(30)] public DatosGlobales datosGlobales;
    // Start is called before the first frame update
    public void UpdateTextPlayerName()
    {
        if (nameText != null)
        {
            nameText.text = greetingMessage.Replace("*",datosGlobales.nombreJugador);
        }
        ChangeBackgroundColor();
    }

    public void ChangeBackgroundColor() 
    {
        if (sceneBackground != null)
        {
            sceneBackground.color = backgroundColors[0].backgroundColorTriggered;
            for (int i = 0; i < backgroundColors.Length; i++)
            {
                    
                if (datosGlobales.nombreJugador.Trim().ToLower() == backgroundColors[i].nameColorTrigger.Trim().ToLower())
                {
                    sceneBackground.color = backgroundColors[i].backgroundColorTriggered;
                }
            }
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
