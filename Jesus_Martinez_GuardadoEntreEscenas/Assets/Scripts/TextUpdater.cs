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
    

    [Space(30)] public DatosGlobales datosGlobales;
    [Space(5)] public Personalizacion personalizacion;

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
            sceneBackground.color = personalizacion.backgroundColors[0].backgroundColorTriggered;
            for (int i = 0; i < personalizacion.backgroundColors.Length; i++)
            {
                    
                if (datosGlobales.nombreJugador.Trim().ToLower() == personalizacion.backgroundColors[i].nameColorTrigger.Trim().ToLower())
                {
                    sceneBackground.color = personalizacion.backgroundColors[i].backgroundColorTriggered;
                }
            }
        }
    }

    public void UpdateTextDifficulty()
    {
        if (difficultyText != null)
        {
            switch (datosGlobales.dificultad) 
            {
                case 1:
                    difficultyText.text = $"{difficultyPrefix} {personalizacion.difficultyName[0]}";
                    break;
                case 2:
                    difficultyText.text = $"{difficultyPrefix} {personalizacion.difficultyName[1]}";
                    break;

                case 3:
                    difficultyText.text = $"{difficultyPrefix} {personalizacion.difficultyName[2]}";
                    break;
            }
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
