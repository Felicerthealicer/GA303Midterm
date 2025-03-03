using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; //referencing the gameobject named "bulletPrefab" 
    public float bulletForce; //creating a float variable named bulletForce
    public Transform bulletSpawnPosition; //creating a transform variable to move an object (the bullet)

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //when you left mouse click...
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.transform.position, bulletSpawnPosition.transform.rotation); //spawn a "bullet" using instantiate in the bulletSpawnPosition's position/rotation

            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletForce); //calling the bullet's Rigidbody to add force to make it go forwards 

            Destroy(bullet, 3f); //destroy the bullet after 3 seconds
        }
    }
}
