using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for the comments

public class Ball : MonoBehaviour {

    private bool isPressed;

    private Rigidbody2D rb; // make sure that you capitalize correctly
    private LineRenderer lr; // this will position the ball where ever the mouse is (I think) 

    // this initiatilizes the different parts?
    private void Awake(){
        Console.WriteLine("Ok ball is seen");
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed){
            DragBall();
        }
    }

    private void DragBall(){
        Console.WriteLine("Clicked!"); // trying to see if this is even being used when I click on the ball

        //SetLineRendererPositions(); // here is where the ball matches position of the mouse
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
