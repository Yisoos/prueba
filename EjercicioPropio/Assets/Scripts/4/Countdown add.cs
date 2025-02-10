using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Countdownadd : MonoBehaviour
{
    [Header("Datos de Dificultad")]
    public DifficultyData difficultyData;
    [Header("TMPro")]
    public Transform scoreAndTimeGroup; 
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text titleText;
    [Header("Textos")]
    [TextArea(1,10)] public string clickToStartText;
    [TextArea(1, 10)] public string finalScoreText;

    [Header("Otro")]
    public Transform LeaderBoardButton;

    private bool isCountdownOn = false;
    private bool canAdd = true;
    private string defaultScoreText;
    private string defaultTimeText;
    // Start is called before the first frame update
    void Start()
    {
        difficultyData.currentScore = 0;
        LeaderBoardButton.gameObject.SetActive(false);
        defaultScoreText = scoreText.text;
        defaultTimeText = timeText.text;
        titleText.text = clickToStartText;
        scoreAndTimeGroup.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
    }
    public void AddPoint()
    {
        if (canAdd)
        {

            if (!isCountdownOn)
            {
                StartCoroutine(CountDown());
            }
            difficultyData.currentScore++;
            scoreText.text = defaultScoreText + difficultyData.currentScore.ToString();
        }
    }

    private IEnumerator CountDown()
    {
        isCountdownOn = true; // Mark countdown as active
        scoreAndTimeGroup.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);

        float timeRemaining = difficultyData.currentDifficulty.timeToPlay;
        while (timeRemaining > 0)
        {
            timeText.text = defaultTimeText + timeRemaining;
            Debug.Log("Countdown: " + timeRemaining.ToString("F1")); // Display countdown in console
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timeRemaining -= 1f; // Decrease remaining time
        }
        timeText.text = defaultTimeText + timeRemaining;
        AddScoreToLeaderBoard();
        ShowFinalScore();
        //Debug.Log("Countdown finished!");
        isCountdownOn = false; // Mark countdown as inactive
        canAdd = false;
    }

    public void ShowFinalScore()
    {
        LeaderBoardButton.gameObject.SetActive(true);
        scoreAndTimeGroup.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
        titleText.text = finalScoreText + difficultyData.currentScore.ToString();
    }
    public void AddScoreToLeaderBoard()
    {
        // Find the correct insertion index for descending order
        int index = difficultyData.leaderBoard.FindIndex(score => score < difficultyData.currentScore);

        // If no smaller score is found, append at the end
        if (index == -1) index = difficultyData.leaderBoard.Count;

        difficultyData.leaderBoard.Insert(index, difficultyData.currentScore);
        difficultyData.leaderBoardDifficulty.Insert(index, difficultyData.currentDifficulty.difficulty);

        // Debug output
        // Debug.Log("Leaderboard Updated: " + string.Join(", ", difficultyData.leaderBoard));
    }


}
