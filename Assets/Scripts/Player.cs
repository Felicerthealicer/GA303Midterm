using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasGreenKey = false; //creating a bool variable to check if player has the green key 
    public bool hasBlueKey = false; //creating a bool variable to check if the player has the blue key
    public bool hasRedKey = false; //creating a bool variable to check if the player has the red key 

    public GameObject playerCamera; //referencing the game object named "playerCamera"


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //When the player presses E...
        {
            RaycastHit hit; // creating the local raycast named "hit"

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10f)) //if the raycast is the playerCamera's forward line of sight, which has a max distance of 10...
            {
                if (hit.collider.gameObject.tag == "Door") //if the raycast collides with a gameobject with the tag "Door" 
                {
                    LockedDoor door = hit.collider.gameObject.GetComponent<LockedDoor>(); //calling the LockedDoor Script in the collider's components 

                    if (door.isDoorLocked == true) //if the door is locked...
                    {
                        if ((door.keyColorRequired == KeyColor.Green && hasGreenKey == true) || //if the keycolor is green and the "hasGreenKey" bool is activated (if the player has the green key) or
                            (door.keyColorRequired == KeyColor.Blue && hasBlueKey == true) || //if the keycolor is blue and the "hasBlueKey" bool is activated (if the player has the blue key) or 
                            (door.keyColorRequired == KeyColor.Red && hasRedKey == true)) //if the keycolor is red and the "hasRedKey" bool is activated (if the player has the red key)
                        {
                            door.OpenDoor(); //calling public void "Open Door" and its functuions from the Locked Door Script 
                        }
                    }
                    
                }
            }
        }
    }
}
