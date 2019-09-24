using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorTimeScale : MonoBehaviour
{
    public float valorTimescale;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = valorTimescale;
    }
}
