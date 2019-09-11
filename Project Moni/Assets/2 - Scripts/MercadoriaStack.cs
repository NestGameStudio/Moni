using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercadoriaStack : MonoBehaviour
{
    // What they do when two objects of the same kind collide

    public int MaxStackSize = 6;
    [Range(1,100)] public float IncreaseSizePercentage = 25;

    private Vector3 IncreaseSize;

    private void Awake() {
        IncreaseSize = this.transform.localScale * (IncreaseSizePercentage/100);

    }

    // Do the combination
    public void CombinateItens(GameObject merch) {

        int StackSize = this.gameObject.GetComponent<Mercadoria>().StackSize;
        int StackSizeCollider = merch.GetComponent<Mercadoria>().StackSize;

        if ((StackSize < MaxStackSize) && (StackSizeCollider < MaxStackSize)) {
            this.gameObject.GetComponent<Mercadoria>().StackSize++;
            this.transform.localScale += IncreaseSize;
            Destroy(merch);
        }

    }

    private void ChangeCombinationText()
    {
        int number = this.gameObject.GetComponent<Mercadoria>().StackSize++;

        this.transform.Find("Combination Counter").GetChild(0).GetComponent<TMPro.TMP_Text>().text = number.ToString();
    }

    // Check the collision
    private void OnCollisionEnter2D(Collision2D collision) {

        // check if the object is a merch
        if (collision.gameObject.GetComponent<Mercadoria>()) {

            // if this object scale is smaller than the cillider scale ignore this function (bug fix to increase the smaller size from both itens)
            if (this.gameObject.GetComponent<Mercadoria>().StackSize >= collision.gameObject.GetComponent<Mercadoria>().StackSize)
            {
                // if this object is being dragged ignore this function (bug fix from both itens disappearing when they collide)
                // if a object collide with eachother and they are not being dragged make the object combine with the lowerst one
                if ((!this.gameObject.GetComponent<DragAndDrop>().Dragging && collision.gameObject.GetComponent<DragAndDrop>().Dragging) ||
                    ((!this.gameObject.GetComponent<DragAndDrop>().Dragging && !collision.gameObject.GetComponent<DragAndDrop>().Dragging) &&
                    (this.transform.position.y < collision.transform.position.y)))
                {

                    GameObject colliderPrefab = collision.gameObject.GetComponent<Mercadoria>().MercadoriaStats.MercadoriaPrefab;

                    if (this.gameObject.GetComponent<Mercadoria>().MercadoriaStats.MercadoriaPrefab == colliderPrefab)
                    {
                        CombinateItens(collision.gameObject);
                    }
                }

            }


        }

    }



}
