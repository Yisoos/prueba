using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public DifficultyData difficultyData;

   public void SetDifficultyTo(string difficulty) 
   {
        if (difficultyData != null) 
        {
            for (int i = 0; i < difficultyData.difficulties.Length; i++) 
            {
                if (difficultyData.difficulties[i].difficulty == difficulty)
                {
                    difficultyData.currentDifficulty = difficultyData.difficulties[i];
                    break;
                }
            }
        }
   }
}
