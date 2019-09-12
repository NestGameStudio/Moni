using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private int ErrorCounter;
    [SerializeField] private int MaxErrorCounter;
    [SerializeField] private EndGameManager EndGManager;

    public void IncreaseErrorCounter()
    {
        ErrorCounter++;
        if(ErrorCounter >= MaxErrorCounter)
        {
            EndGManager.EndGame();
        }
    }

    public void AddPointsToScore(int points)
    {
        this.transform.Find("Score").GetComponent<Score>().AddScore(points);
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
