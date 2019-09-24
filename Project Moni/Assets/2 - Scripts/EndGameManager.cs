using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPopup;
    [SerializeField] private Transform merchandisesInGameRef;
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject points;
    [SerializeField] private TextMeshProUGUI finalScore;

    private List<GameObject> merchandiseList;

    public void EndGame()
    {
        merchandiseList = new List<GameObject>();
        for (int i = 0; i < merchandisesInGameRef.childCount; i++)
        {
            merchandiseList.Add(merchandisesInGameRef.GetChild(i).gameObject);
            merchandiseList[i].GetComponent<Rigidbody2D>().simulated = false;
        }
        StartCoroutine(CollectItemPointsInCart());
    }

    private IEnumerator CollectItemPointsInCart()
    {
        Mercadoria merch;
        Debug.Log(merchandiseList.Count);
        for(int i = 0 ; i < merchandiseList.Count - 1 ; i++)
        {
            Debug.Log(i);
            merch = merchandiseList[i].GetComponent<Mercadoria>();
            
            gm.AddScoreBasedOnStackSize(merch.StackSize, 6, merch.MercadoriaStats.Value);
            Destroy(merch.gameObject);
            yield return new WaitForSeconds(1f);
        }

        ShowEndGamePopup();
    }

    private void ShowEndGamePopup()
    {
        _gameOverPopup.SetActive(true);
        finalScore.text = points.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
        points.SetActive(false);
    }
}
