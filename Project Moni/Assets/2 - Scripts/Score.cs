using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI textDisplay;

    private void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddScore(int scoreChange) => score += scoreChange;

    public void UpdateScoreDisplay() => textDisplay.text = score.ToString();
}
