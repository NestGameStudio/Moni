using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPopup;

    public void EndGame()
    {
        _gameOverPopup.SetActive(true);
        Time.timeScale = 0;
    }
}
