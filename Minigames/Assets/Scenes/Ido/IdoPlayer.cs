using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdoPlayer : MonoBehaviour
{

    [SerializeField] Rigidbody2D body;

    float moveSpeed = 7f;

    public void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Crown")
        {
            // Set the player as the parent of the collided object
            collision.transform.SetParent(transform);
            collision.transform.localPosition = new Vector2(0f, 0f);
            
            // Disable collision on the parent object
            GetComponent<Collider2D>().enabled = false;

            // Enable collision on the child object
            collision.enabled = true;

            // Start a coroutine to check and enable the collider on the previous parent object after 2 seconds
            StartCoroutine(CheckEnableCollisionAfterDelay(GetComponent<Collider2D>(), 3f));
        }
    }

    private IEnumerator CheckEnableCollisionAfterDelay(Collider2D collider, float delay)
{
    yield return new WaitForSeconds(delay);

    // Wait until the previous parent object loses its child object
    while (transform.childCount > 0)
    {
        yield return null;
    }
        // Enable collision on the collider of the previous parent object
        collider.enabled = true;
    }

}

