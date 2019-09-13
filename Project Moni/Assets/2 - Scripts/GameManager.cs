using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private int ErrorCounter;
    [SerializeField] private int MaxErrorCounter;
    [SerializeField] private EndGameManager EndGManager;
    [SerializeField] private Score score;

    public void IncreaseErrorCounter()
    {
        ErrorCounter++;
        if(ErrorCounter >= MaxErrorCounter)
        {
            EndGManager.EndGame();
        }
    }

    // Façades for score >>>>
    [SerializeField] private float stackCompleteBonus;
    public void AddScoreBasedOnStackSize(int stackSize, int maxStackSize, int merchValue)
    {
        int scoreToGive = merchValue * stackSize;

        if (stackSize >= maxStackSize)
        {
            scoreToGive = scoreToGive * (int)stackCompleteBonus;
        }

        score.AddScore(scoreToGive);
        score.UpdateScoreDisplay();
    }

    
    public void AddPointsToScore(int points)
    {
        this.transform.Find("Score").GetComponent<Score>().AddScore(points);
    }
    // <<<<<
}
