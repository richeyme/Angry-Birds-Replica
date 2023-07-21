using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private bool isPressed;

    private Rigidbody2D rb; // make sure that you capitalize correctly

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed){
            DragBall();
        }
    }

    private void DragBall(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Converts the mouse position on screen to a point
        rb.position = mousePosition; // That point is now the point of the object
    }

    /*
     * This happens when player clicks
     */
    private void OnMouseDown(){
        isPressed = true;
    }

    /*
     * This happens when player releases the click
     */
    private void OnMouseUp(){
        isPressed = false;
    }
}
