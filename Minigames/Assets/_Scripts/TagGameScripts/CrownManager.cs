using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownManager : MonoBehaviour
{
<<<<<<< Updated upstream

    public AudioSource touchCrown;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set the player as the parent of the collided object
            collision.transform.SetParent(transform, true);

            // Rotate the collided object to match its parent's rotation
            collision.transform.rotation = transform.rotation;

            touchCrown.Play();
        }
    }
=======
>>>>>>> Stashed changes
}




