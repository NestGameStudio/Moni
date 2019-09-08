using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercadoriaStack : MonoBehaviour
{
    // When two objects 

    public int MaxStackSize = 6;
    public float IncreaseSizePercentage = 25;

    private Vector3 IncreaseSize;

    private void Awake() {
        IncreaseSize = this.transform.localScale * (IncreaseSizePercentage/100);
    }

    // Do the combination
    public void CombinateItens(GameObject merch) {

        int StackSize = this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize;
        int StackSizeCollider = merch.GetComponent<MercadoriaInstance>().Mercadoria.StackSize;

        if ((StackSize < MaxStackSize) && (StackSizeCollider < MaxStackSize)) {
            this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize++;
            this.transform.localScale += IncreaseSize;
            Destroy(merch);
        }

    }

    // Check the collision
    void OnCollisionEnter2D(Collision2D collision) {

        // check if the object is a merch
        if (collision.gameObject.GetComponent<MercadoriaInstance>()) {

            // if this object is being dragged ignore this function (bug fix from both itens disappearing when they collide)
            // if a object collide with eachother and they are not being dragged make the object combine with the lowerst one
            if ((!this.gameObject.GetComponent<DragAndDrop>().Dragging && collision.gameObject.GetComponent<DragAndDrop>().Dragging) || 
                ((!this.gameObject.GetComponent<DragAndDrop>().Dragging && !collision.gameObject.GetComponent<DragAndDrop>().Dragging) &&
                (this.transform.position.y < collision.transform.position.y))) {

                GameObject colliderPrefab = collision.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.MercadoriaPrefab;

                if (this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.MercadoriaPrefab == colliderPrefab) {
                    CombinateItens(collision.gameObject);
                }
            }


        }

    }



}
