using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor
{
    Blue,
    Green,
    Yellow,
    Red
}
public class BulletHandeler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public PlayerColor bulletColor;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet Destroyer"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<TankHandeler>().tankColor != bulletColor)
            {
                TankBattleGameManager.instance.AddToScore(bulletColor);
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
