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

    public void Forward() // cancels rotation and moves forward
    {
        transform.Rotate(0f, 0f, -100 * Time.deltaTime, Space.Self);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }

    private void ScreenWrap() // Makes the player appear on the opposite side of the screen
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
            StartCoroutine(TransferCrownWithDelay(collision.transform, 0.2f, 0.2f)); // Change the delay time here (e.g., 0.5f)
        }
    }

    private IEnumerator TransferCrownWithDelay(Transform crownTransform, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Set the player as the parent of the crown
        crownTransform.SetParent(transform);
        crownTransform.localPosition = Vector2.zero;

        // Disable collision on the parent object
        GetComponent<Collider2D>().enabled = false;

        // Disable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(delay); // Wait for another delay

        // Enable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = true;

        // Enable collision on the parent object
        GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator TransferCrownWithDelay(Transform crownTransform, float crownDelay, float playerDelay)
    {
        yield return new WaitForSeconds(crownDelay);

        // Set the player as the parent of the crown
        crownTransform.SetParent(transform);
        crownTransform.localPosition = Vector2.zero;

        // Disable collision on the parent object
        GetComponent<Collider2D>().enabled = false;

        // Disable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(playerDelay); // Wait for the player delay

        // Enable collision on the parent object
        GetComponent<Collider2D>().enabled = true;

        yield return new WaitForSeconds(crownDelay); // Wait for the crown delay

        // Enable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = true;
    }
}

