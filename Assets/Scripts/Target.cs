using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType //creating an enumeration named TargetType; can be catagorized into Destroyable, Moveable, and DestroyableWithSound 
{
    Destroyable,
    Movable,
    DestroyableWithSound
}

public class Target : MonoBehaviour
{ 
    public AudioSource targetSound; //referencing an audio sound that will be played 
    public TargetType targetType; //creating an variable for enum to be called throughout this script 
    private Vector3 startingPosition; //creating a Vector3 of the starting position of the Moveable target
    public float maxMovingTargetRange = 3f; //creating a variable for how far Moveable target will move 

    void Start()
    {
        startingPosition = this.transform.position; //the starting position is the game object's transform position 

        if (targetType == TargetType.Destroyable) //if the target type is Destroyable...
        {
            this.GetComponent<MeshRenderer>().material.color = Color.magenta; //change this game object's color to magenta.
        }
        else if (targetType == TargetType.Movable) //if the target type is Moveable...
        {
            this.GetComponent<MeshRenderer>().material.color = Color.cyan; //change this game object's color to cyan.
        }
        else if (targetType == TargetType.DestroyableWithSound) //if the target type is DestroyableWithSound...
        {
            this.GetComponent<MeshRenderer>().material.color = Color.yellow; //change this game object's color to yellow.
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet") //if the other game object this game object collided with has the tag "Bullet" 
        {

            if(targetType == TargetType.Destroyable) //if the target type is Destroyable...
            {
                this.gameObject.SetActive(false); //set this game object (the target) to inactive.

            }
            else if(targetType == TargetType.Movable) //if the target type is Moveable...
            {
                float randomY = Random.Range(-maxMovingTargetRange, maxMovingTargetRange); //creating a float variable for y that will move the target vertically at a randomized interval between -3 to 3
                float randomZ = Random.Range(-maxMovingTargetRange, maxMovingTargetRange); //creating a float variable for z that will move the target horizontally at a randomized interval between -3 to 3

                this.transform.position = startingPosition + new Vector3(0f, randomY, randomZ); //moveable target will move from its current transform position to the starting position + new Vector with randomized y and z intervals 
            }
            else if (targetType == TargetType.DestroyableWithSound) //if the target type is DestroyableWithSound...
            {
                targetSound.Play(); //play the audio 
                this.gameObject.SetActive(false); //set this game obejct (the target) to inactive.
            }

            Destroy(other.gameObject); //destroy the bullet once it collides with the target 

        }
    }

    public void ReactivateTarget()
    {
        this.gameObject.SetActive(true); //sets this game object to active 
    }

}