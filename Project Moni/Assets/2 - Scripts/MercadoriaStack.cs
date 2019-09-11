using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            ChangeCombinationNumber();
            this.transform.localScale += IncreaseSize;
            Destroy(merch);
        }

        if (StackSize == MaxStackSize) {

            Destroy(this.gameObject);

            // Chama a função dos pontos

        }

    }

    private void ChangeCombinationNumber() {

        int stackSize = this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize;
        Debug.Log(stackSize);

        foreach (Transform child in this.GetComponentInChildren<Transform>(true)) {

            // find the deactivated counter
            if (child.name == "Combination Number") {

                // activate the game object if it is not active and the stack size is bigger than 1
                if (stackSize > 1 && !child.gameObject.activeSelf)
                    child.gameObject.SetActive(true);

                if (child.gameObject.activeSelf) {
                    child.transform.GetChild(0).GetComponent<TMP_Text>().text = stackSize.ToString();
                }

            }
        }

    }

    // Check the collision
    void OnCollisionEnter2D(Collision2D collision) {

        // check if the object is a merch
        if (collision.gameObject.GetComponent<MercadoriaInstance>()) {

            // if this object collide with another bigger than him (with more combinations) ignore this fuction (bug fix from the increase of size)
            if (collision.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize <= this.gameObject.GetComponent<MercadoriaInstance>().Mercadoria.StackSize) {

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



}
