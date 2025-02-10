using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    public DifficultyData difficultyData;
    public TMP_Text leaderBoard;
    public TMP_Text currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = "Current Score: " + difficultyData.currentScore.ToString();
        UpdateLeaderBoard();
    }

    public void UpdateLeaderBoard()
    {
        leaderBoard.text = "";
        int count = Mathf.Min(5, difficultyData.leaderBoardDifficulty.Count, difficultyData.leaderBoard.Count); // Get the smallest valid index range

        for (int i = 0; i < count; i++) // Prevent out-of-bounds access
        {
            if (difficultyData.leaderBoardDifficulty[i] != null)
            {
                leaderBoard.text += $"{i + 1}. {difficultyData.leaderBoardDifficulty[i]} - {difficultyData.leaderBoard[i]}\n";
            }
            else
            {
                leaderBoard.text += $"{i + 1}.\n";
            }
        }

        // Fill remaining lines if there are fewer than 5 entries
        for (int i = count; i < 5; i++)
        {
            leaderBoard.text += $"{i + 1}.\n";
        }
    }

    public void ClearLeaderBoard()
    {
        difficultyData.leaderBoard.Clear();
        difficultyData.leaderBoardDifficulty.Clear();
        UpdateLeaderBoard();
    }
}


