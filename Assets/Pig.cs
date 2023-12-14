using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{

    // This script is meant to track when the pig is touched in game

    public float health = 4f; // health of the pig
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
        Destroy(gameObject); // will make the pig disappear from the game
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
