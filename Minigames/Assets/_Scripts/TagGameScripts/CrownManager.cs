using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Set the player as the parent of the collided object
            collision.transform.SetParent(transform, true);

            // Rotate the collided object to match its parent's rotation
            collision.transform.rotation = transform.rotation;
        }
    }
}
