using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercadoriaStack : MonoBehaviour
{
    // What they do when two objects of the same kind collide

    // ============ Attributes ============
    // External references
    private TMPro.TMP_Text counterText;
    [HideInInspector] public GameManager gm;
    [SerializeField] private Mercadoria mercadoriaScript;

    // Internal variables
    private Vector3 IncreaseSize;

    // External variables (GD Tools)
    public int MaxStackSize = 6;
    [Range(1,100)] public float IncreaseSizePercentage = 25;


    // =========== Methods ===========
    private void Awake() {
        IncreaseSize = this.transform.localScale * (IncreaseSizePercentage/100);

        // Get the counter text from the gameobject
        foreach (Transform child in this.transform.GetComponentInChildren<Transform>(true)) {

            if (child.name == "Combination Counter") {
                counterText = child.GetChild(0).GetComponent<TMPro.TMP_Text>();
            }
        }

        mercadoriaScript = this.GetComponent<Mercadoria>();
    }

    // Do the combination
    public void CombinateItens(GameObject merch) {

        int StackSizeCollider = merch.GetComponent<Mercadoria>().StackSize;

        if ((mercadoriaScript.StackSize < MaxStackSize) && (StackSizeCollider < MaxStackSize)) {

            mercadoriaScript.StackSize += StackSizeCollider;
			ChangeCombinationText(mercadoriaScript.StackSize);
			this.transform.localScale += IncreaseSize;
            Destroy(merch);
        }

        if (mercadoriaScript.StackSize == MaxStackSize) {

            gm.AddScoreBasedOnStackSize(mercadoriaScript.StackSize, MaxStackSize, mercadoriaScript.MercadoriaStats.Value);

            // remove the object from the cart
            Destroy(this.gameObject);
        }

    }

    private void ChangeCombinationText(int stackSize)
    {
        //int number = this.gameObject.GetComponent<Mercadoria>().StackSize;

        // Activate the counter child
        if (stackSize > 1 && !counterText.transform.parent.gameObject.activeSelf) {
            counterText.transform.parent.gameObject.SetActive(true);
        }

        // change the text
        if (counterText) {
            counterText.text = stackSize.ToString();
        }

    }

    // Check the collision
    private void OnCollisionEnter2D(Collision2D collision) {

        // check if the object is a merch
        if (collision.gameObject.GetComponent<Mercadoria>()) {

            // if this object scale is smaller than the cillider scale ignore this function (bug fix to increase the smaller size from both itens)
            if (this.gameObject.GetComponent<Mercadoria>().StackSize >= collision.gameObject.GetComponent<Mercadoria>().StackSize)
            {
                // if this object is being dragged ignore this function (bug fix from both itens disappearing when they collide)
                // if an object collides with another and they are not being dragged make the object combine with the lowest one
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
