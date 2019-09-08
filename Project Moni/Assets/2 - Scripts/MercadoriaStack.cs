using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercadoriaStack : MonoBehaviour
{
    //quando um item combina ele cresce de tamanho e aumenta o stack size
    //o stack size fica na classe individual de mercadoria

    public int MaxStackSize = 6;

    // Do the combination
    public void CombinateItens(GameObject merch) {

        int StackSize = this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize;
        int StackSizeCollider = merch.GetComponent<MercadoriaInstance>().Mercadoria.StackSize;

        if ((StackSize < MaxStackSize) && (StackSizeCollider < MaxStackSize)) {
            this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize++;
            this.transform.localScale += this.transform.localScale * 0.25f;
            Destroy(merch);
        }

    }

    // Check the collision
    void OnCollisionEnter2D(Collision2D collision) {


        if (collision.gameObject.GetComponent<MercadoriaInstance>()) {
            GameObject colliderPrefab = collision.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.MercadoriaPrefab;

            if (this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.MercadoriaPrefab == colliderPrefab) {
                CombinateItens(collision.gameObject);
            }
        }

    }



}
