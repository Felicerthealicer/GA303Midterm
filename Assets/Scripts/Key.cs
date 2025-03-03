using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor //creating an enumeration named KeyColor; can be catagorized into green, blue, or red
{
    Green,
    Blue,
    Red
}

public class Key : MonoBehaviour
{
    public KeyColor keyColor; //creating a variable for enum to be called throughout this script 

    private void Start()
    {

        if(keyColor == KeyColor.Green) //if the keycolor is green...
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; //change this game object's color to green.
        }
        else if (keyColor == KeyColor.Blue) //if the keycolor is blue...
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue; //change this game object's color to blue.
        }
        else if (keyColor == KeyColor.Red) //if the keycolor is red...
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red; //change this gameobject's color to red.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //if the other object collided into this object has the tag "Player"...
        {
            Player player = other.gameObject.GetComponent<Player>(); //calling reference to the Player Script named "player"

            if (keyColor == KeyColor.Green) //if the keycolor is green...
            {
                if (player.hasGreenKey == false) //if the "hasGreenKey" bool is not activated (if the player does not have the green key)...
                {
                    player.hasGreenKey = true; //"hasGreenKey" is activated (the player now has the green key).
                    Destroy(this.gameObject); //destroy this game object (green key).
                }
            }
            else if (keyColor == KeyColor.Blue) //if the keycolor is blue...
            {
                if (player.hasBlueKey == false) //if the "hasBlueKey" bool is not activated (if the player does not have the blue key)...
                {
                    player.hasBlueKey = true; //"hasBlueKey" is activated (the player now has the blue key).
                    Destroy(this.gameObject); //destroy this game object (blue key).
                }
            }
            else if (keyColor == KeyColor.Red) //if the keycolor is red...
            {
                if (player.hasRedKey == false) //if the "hasRedKey" bool is not activated (if the player does not have the red key)...
                {
                    player.hasRedKey = true; //"hasRedKey" is activated (player now has the red key).
                    Destroy(this.gameObject); //destroy this game object (red key).
                }
            }
            
        }
    }
}
