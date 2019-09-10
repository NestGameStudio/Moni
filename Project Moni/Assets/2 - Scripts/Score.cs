using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] private Text textDisplay;

    public void AddScore(int scoreChange) => score += scoreChange;

    public void UpdateScoreDisplay() => textDisplay.text = score.ToString();
}
