using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercadoria : MonoBehaviour {

    // dar um jeito dos itens nao subirem de velocidade sem drama

    public MercadoriaStats MercadoriaStats;
    [HideInInspector] public int StackSize = 1;
}
