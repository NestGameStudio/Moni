using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercadoriaStack : MonoBehaviour
{
     //quando um item combina ele cresce de tamanho e aumenta o stack size
     //o stack size fica na classe individual de mercadoria

    private int StackSize;

    public void Awake() {

        //StackSize = this.gameObject.GetComponent<Mercadoria>().StackSize;
    }



    
}
