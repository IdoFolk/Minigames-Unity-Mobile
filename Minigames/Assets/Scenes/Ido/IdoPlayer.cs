using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdoPlayer : MonoBehaviour
{

    [SerializeField] Rigidbody2D body;

    float moveSpeed = 7f;

    public void Update()
    {
        
        transform.Rotate(0f, 0f, 100 * Time.deltaTime, Space.Self);
        ScreenWrap();
     
    }

    public void Foward() // canceles rotation on moves foward
    {
        transform.Rotate(0f, 0f, -100 * Time.deltaTime, Space.Self);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);

    }


    private void ScreenWrap() // Makes you appear on the oppisite side of the screen
    {

        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;
        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x;
            transform.position = newPosition;
        }

        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Crown")
        {
            // Set the player as the parent of the collided object
            Debug.Log("2134");
            collision.transform.SetParent(transform, true);
        }
    }
}
