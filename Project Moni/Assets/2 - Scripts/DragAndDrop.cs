using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // Drag the itens

    private bool dragging = false;
    private float distance;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging){

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.freezeRotation = true;
            rb.Sleep();
            rb.MovePosition(rayPoint);

        } else {

            rb.freezeRotation = false;
        }

    }
}
