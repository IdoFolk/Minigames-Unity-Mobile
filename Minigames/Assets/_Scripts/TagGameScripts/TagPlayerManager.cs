using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using UnityEngine;


public class TagPlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    float moveSpeed = 7f;

    public void Update()
    {
        
            if (MiniGameManager.IsPaused) return;   

=======
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TagGameManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    [SerializeField] float moveSpeed = 7f;

    public void Update()
    {
>>>>>>> Stashed changes
        transform.Rotate(0f, 0f, 100 * Time.deltaTime, Space.Self);
        ScreenWrap();
    }

    public void Forward() // cancels rotation and moves forward
    {
<<<<<<< Updated upstream
        if (MiniGameManager.IsPaused) return;
        transform.Rotate(0f, 0f, -100 * Time.fixedDeltaTime, Space.Self);
=======
        transform.Rotate(0f, 0f, -100 * Time.deltaTime, Space.Self);
>>>>>>> Stashed changes
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }

    private void ScreenWrap() // Makes the player appear on the opposite side of the screen
    {
<<<<<<< Updated upstream
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
=======

            Vector3 newPosition = body.transform.position;
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(body.transform.position);
            if (viewportPosition.x > 1)
            {
                newPosition.x = -newPosition.x + 0.1f;
            }
            else if (viewportPosition.x < 0)
            {
                newPosition.x = -newPosition.x - 0.1f;

            }
        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        body.transform.position = newPosition;

}

    private bool isCrownTaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCrownTaken) // Check if the player already has the crown
        {
            return; // Exit the method early
        }

        if (collision.gameObject.name == "Crown" && !isCrownTaken)
        {
            isCrownTaken = true;
>>>>>>> Stashed changes
            StartCoroutine(TransferCrownWithDelay(collision.transform, 0f, 1f)); // Change the delay time here (e.g., 0.5f)
        }
    }

    private IEnumerator TransferCrownWithDelay(Transform crownTransform, float crownDelay, float playerDelay)
    {
        // Set the player as the parent of the crown
        crownTransform.SetParent(transform);
        crownTransform.localPosition = Vector2.zero;

        // Disable collision on the parent object
<<<<<<< Updated upstream
        GetComponent<Collider2D>().enabled = false;

        // Disable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = false;
=======
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        // Disable collision on the child object (crown)
        Collider2D crownCollider = crownTransform.GetComponent<Collider2D>();
        if (crownCollider != null)
        {
            crownCollider.enabled = false;
        }
>>>>>>> Stashed changes

        yield return new WaitForSeconds(crownDelay); // Wait for the crown delay

        // Enable collision on the parent object
<<<<<<< Updated upstream
        GetComponent<Collider2D>().enabled = true;
=======
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }
>>>>>>> Stashed changes

        yield return new WaitForSeconds(playerDelay); // Wait for the player delay

        // Enable collision on the child object (crown)
<<<<<<< Updated upstream
        crownTransform.GetComponent<Collider2D>().enabled = true;
    }
=======
        if (crownCollider != null)
        {
            crownCollider.enabled = true;
        }

        // Check if the player still has the crown
        if (isCrownTaken)
        {
            isCrownTaken = false; // Allow players to take the crown again
        }
    }

>>>>>>> Stashed changes
}

