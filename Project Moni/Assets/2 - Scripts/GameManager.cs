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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
