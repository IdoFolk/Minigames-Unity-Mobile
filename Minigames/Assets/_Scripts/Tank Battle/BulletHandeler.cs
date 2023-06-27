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
        if (TankBattleGameManager.Instance.GamePaused) return;
        transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (TankBattleGameManager.Instance.GamePaused) return;
        if (collision.gameObject.CompareTag("Bullet Destroyer"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TankBattleGameManager.Instance.GamePaused) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerColor tankColor = collision.gameObject.GetComponent<TankHandeler>().tankColor;
            if (tankColor != bulletColor)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                TankBattleGameManager.Instance.AddToScore(bulletColor);
                TankBattleGameManager.Instance.RemoveTank(tankColor);
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
