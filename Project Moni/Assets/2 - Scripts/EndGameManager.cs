using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPopup;

    private void Start()
    {
        Time.timeScale = 1;        
    }
    public void EndGame()
    {
        _gameOverPopup.SetActive(true);
        Time.timeScale = 0;
    }
}
