using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TagGameManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    [SerializeField] float moveSpeed = 7f;

      

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

            TransferCrownWithDelay(collision.transform, 1.0f); // Change the delay time here
        }
    }

    private void TransferCrownWithDelay(Transform crownTransform, float delay)
    {
        // Set the player as the parent of the crown
        crownTransform.SetParent(transform);
        crownTransform.localPosition = Vector2.zero;

        // Disable collision on the parent object
        GetComponent<Collider2D>().enabled = false;

        // Disable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = false;

        StartCoroutine(EnableCrownCollisionWithDelay(crownTransform, delay));
    }

    private IEnumerator EnableCrownCollisionWithDelay(Transform crownTransform, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Enable collision on the child object (crown)
        crownTransform.GetComponent<Collider2D>().enabled = true;

        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        // Enable collision on the parent object
        GetComponent<Collider2D>().enabled = true;
    }


}

