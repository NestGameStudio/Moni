using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyObject : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mercadoria")
        {
            Destroy(collision.gameObject);
            gm.IncreaseErrorCounter();
        }
    }
}
