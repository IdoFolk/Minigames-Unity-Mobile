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
            Debug.Log("2134");
            collision.transform.SetParent(transform, true);
        }
    }
}
