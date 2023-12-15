using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Pig : MonoBehaviour
{

    // This script is meant to track when the pig is touched in game

    public float health = 4f; // health of the pig
    public GameObject deathEffect;
    public static int PigsAlive = 0;

    // for the win condition
    public TextMeshProUGUI levelWon;


    // Start is called before the first frame update
    void Start()
    {
        PigsAlive++;
    }

    void OnCollisionEnter2D(Collision2D colInfo){
        // rel vel is a 2d vector that compares the speed of one obj to another
        // mag is just like physics, combines both components to get a val
        // ALSO OF NOTE: The Debug.Log prints to the console when the game is running, so not needed for the actual method
        //Debug.Log(colInfo.relativeVelocity.magnitude);

        // if the impact that the pig takes is greater than its given health, die
        if(colInfo.relativeVelocity.magnitude > health){
            Die(); // die method to be implemented
        } 
    }

    void Die(){
        Instantiate(deathEffect, transform.position, Quaternion.identity); // will start the particle effect when pig dies

        PigsAlive--; // making sure that the pigs that are dying are being accounted for
        
        // if we have killed all the pigs
        if(PigsAlive <= 0){
            // pop up for the win should go in here
            GetComponent<Canvas>().gameObject.SetActive(true); // will allow the text to appear once win condition met
            Debug.Log("LEVEL WON!"); // just prints to the console
        }

        Destroy(gameObject); // will make the pig disappear from the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
