using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for the comments

public class Ball : MonoBehaviour {

    private bool isPressed;

    private float releaseDelay = .15f; // this is related to the period or how many times it swings in 1 sec
    private float maxDragDist = 2f; // this should limit how far it can be dragged from the spring

    private Rigidbody2D rb; // make sure that you capitalize correctly
    private SpringJoint2D sj; // for the thing that is holding the ball from flying
    private Rigidbody2D slingRb; // this related to the sling that will be holding the ball in place

    // this initiatilizes the different parts
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        slingRb = sj.connectedBody; 

      //  releaseDelay = 1/ (sj.frequency * 4); // want it to be 1/4 of the period (essentially released when it passes the blue part)
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

        float dist = Vector3.Distance(mousePosition,slingRb.position);// get the distance between when the bird is being dragged and the sling

        // now compare to max dist
        if(dist > maxDragDist){
            // this assures that you cannot drag it past the length of the sling but still follows the mouse
            Vector2 direction = (mousePosition - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDist;
        } else {
            rb.position = mousePosition; // That point is now the point of the object
        }
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
        rb.isKinematic = false; // should fall
        StartCoroutine(Release()); // calls the method. Needs to be written this way because it is of type IEnumerator
    }

    // not sure what IEnumerated is, should look up
    private IEnumerator Release(){
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false; //disables the joint so that it is released and lets ball fly away
    }
}
