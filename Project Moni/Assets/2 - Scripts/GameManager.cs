﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private int ErrorCounter;
    [SerializeField] private int MaxErrorCounter;

    public void IncreaseErrorCounter()
    {
        ErrorCounter++;
        if(ErrorCounter >= MaxErrorCounter)
        {
            
        }
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
