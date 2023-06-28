using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHandeler : MonoBehaviour
{
    public bool isMoving;
    public bool rotateDirection;
    public PlayerColor tankColor;

    [SerializeField] float rotationSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Rigidbody2D PlayerActorRB;

    private void Update()
    {
        KeepPlayerOnScreen();
    }
    private void FixedUpdate()
    {
        MovementHandeler();
    }
    public void Shoot()
    {
        if (MiniGameManager.IsPaused) return;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<BulletHandeler>().bulletColor = tankColor;
    }
    public void Move(bool state)
    {
        if (MiniGameManager.IsPaused) return;
        isMoving = state;
    }
    public void SwitchRotateDirection()
    {
        if (MiniGameManager.IsPaused) return;
        rotateDirection = !rotateDirection;
    }
    private void MovementHandeler()
    {
        if (!isMoving)
        {
            if (rotateDirection)
                transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
            else
                transform.Rotate(Vector3.back * rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if (MiniGameManager.IsPaused) return;
            transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
        }
    }
    private void KeepPlayerOnScreen()
    {
        if (MiniGameManager.IsPaused) return;
        Vector3 newPosition = PlayerActorRB.transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(PlayerActorRB.transform.position);
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
        PlayerActorRB.transform.position = newPosition;
    }


}
