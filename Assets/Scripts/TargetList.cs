using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetList : MonoBehaviour
{

    public List<Target> targets = new List<Target>(); //creating a new list in the inspector for the Target Script 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targets = FindObjectsByType<Target>(FindObjectsSortMode.None).ToList(); //objects, named targets, added to list if they have the Target Script attached
        GameObject.FindGameObjectsWithTag("Target").ToList(); //game objects with the tag "Target" will be added to the list 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //when you click R...
        {
            foreach (Target target in targets) //goes through the list for each of the components within the list 
            {
                target.ReactivateTarget(); //references the public void "ReactivateTarget" and its functions from the Target Script 
            }
        }
    }
}
