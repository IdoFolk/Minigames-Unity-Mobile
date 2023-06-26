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


    private void FixedUpdate()
    {
        MovementHandeler();
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<BulletHandeler>().bulletColor = tankColor;
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
            transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
        }
    }
   

}