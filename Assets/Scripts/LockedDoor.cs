using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public KeyColor keyColorRequired; //creating a variable for enum to be called throughout this script 

    public Transform doorFinalPosition; //creating a transform vairable to move an object (the door) 

    public bool isDoorLocked = true; //creating a bool variable to check if the door is locked


    private void Start()
    {
        if (keyColorRequired == KeyColor.Green) //if the keycolor is green...
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; //change the game object's color to green 
        }
        else if (keyColorRequired == KeyColor.Blue) //if the keycolor is blue...
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue; //change the game object's color to blue
        }
        else if (keyColorRequired == KeyColor.Red) //if the keycolor is red...
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red; //change the game object's color to red
        }
    }

    public void OpenDoor()
    {
        this.transform.position = doorFinalPosition.transform.position; //change this game object's position to doorFinalPosition 
    }
}
