using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for the comments

public class Ball : MonoBehaviour {

    private bool isPressed;

    private float releaseDelay; // this is related to the period or how many times it swings in 1 sec
    private Rigidbody2D rb; // make sure that you capitalize correctly
    private SpringJoint2D sj; // for the thing that is holding the ball from flying

    // this initiatilizes the different parts
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();

        releaseDelay = 1/ (sj.frequency * 4); // want it to be 1/4 of the period (essentially released when it passes the blue part)
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
        rb.isKinematic = true; // this makes it so that the ball follows exactly where it is supposed to be
    }

    /*
     * This happens when player releases the click
     */
    private void OnMouseUp(){
        isPressed = false;
        rb.isKinematic = false; // should fall?
        StartCoroutine(Release()); // calls the method but I want to look up exactly what this is referring to
    }

    // not sure what IEnumerated is, should look up
    private IEnumerator Release(){
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false; //disables the joint so that it is released and lets ball fly away
    }
}
