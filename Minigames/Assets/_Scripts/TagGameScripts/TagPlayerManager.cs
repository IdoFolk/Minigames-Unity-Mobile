using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TagPlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    float moveSpeed = 7f;


    public void Update()
    {

        transform.Rotate(0f, 0f, 100 * Time.deltaTime, Space.Self);
        KeepPlayerOnScreen();
    }

    public void Forward() // cancels rotation and moves forward
    {

        if (MiniGameManager.IsPaused) return;
        transform.Rotate(0f, 0f, -100 * Time.deltaTime, Space.Self);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }

    private void KeepPlayerOnScreen()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Crown")
        {
            StartCoroutine(TransferCrownWithDelay(collision.transform, 0f, 1f)); // Change the delay time here (e.g., 0.5f)
        }
    }

    private IEnumerator TransferCrownWithDelay(Transform crownTransform, float crownDelay, float playerDelay)
    {
        // Set the player as the parent of the crown
        crownTransform.SetParent(transform);
        crownTransform.localPosition = Vector2.zero;

        // Disable collision on the parent object
        GetComponent<Collider2D>().enabled = false;

        // Disable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(crownDelay); // Wait for the crown delay

        // Enable collision on the parent object
        GetComponent<Collider2D>().enabled = true;

        yield return new WaitForSeconds(playerDelay); // Wait for the player delay

        // Enable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = true;
    }
}



