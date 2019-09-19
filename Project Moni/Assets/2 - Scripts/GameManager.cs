using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // External references
    [SerializeField] private EndGameManager EndGManager;
    [SerializeField] private Score score;

    // Internal variables
    private int ErrorCounter;

    // External variables (GD tools)
    [SerializeField] private int MaxErrorCounter;

    private bool isEndingGame = false;
    public void IncreaseErrorCounter()
    {
        ErrorCounter++;
        if(ErrorCounter >= MaxErrorCounter && isEndingGame == false)
        {
            isEndingGame = true;
            GetComponent<Spawner>().StopSpawning();
            EndGManager.EndGame();
        }
    }

    // Façades for score >>>>
    [SerializeField] private float stackCompleteBonus;
    public void AddScoreBasedOnStackSize(int stackSize, int maxStackSize, int merchValue)
    {
        int scoreToGive = merchValue * stackSize;
        float scoreToGiveFloat = (float) scoreToGive;

        if (stackSize >= maxStackSize)
        {
            scoreToGiveFloat = scoreToGiveFloat * stackCompleteBonus;
        }

        score.AddScore((int)scoreToGiveFloat);
        score.UpdateScoreDisplay();
    }
    // <<<<<
}
