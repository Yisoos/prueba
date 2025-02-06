using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdownadd : MonoBehaviour
{
    [Header("Datos de Dificultad")]
    public DifficultyData difficultyData;
    [Header("TMPro")]
    public TMP_Text scoreText;
    public TMP_Text TimeText;
    public TMP_Text titleText;
    public Button addPointButton;
    public Transform scoreAndTimeGroup; 
    // Start is called before the first frame update
    void Start()
    {
        scoreAndTimeGroup.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
