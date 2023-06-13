using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandeler : MonoBehaviour
{
    public bool isMoving;

    [SerializeField] float rotationSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bulletPrefab;

    private bool shot;

    private void FixedUpdate()
    {
        MovementHandeler();
    }
    public void Shoot()
    {
        if (!shot)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            shot = true;
        }
    }
    private void MovementHandeler()
    {
        if (!isMoving)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
        }
    }

}
