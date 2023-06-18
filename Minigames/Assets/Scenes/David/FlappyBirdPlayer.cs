using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    public void Thrust()
    {
        if (FlappyBirdMiniGameManager.isPaused) return;
        body.velocity = Vector2.up * 7;
    }
    public void ActivateBody()
    {
        body.WakeUp();
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        ((FlappyBirdMiniGameManager)MiniGameManager.instace).CheckPlayers();
    }
    public void Pause(bool pause)
    {
        body.simulated = pause;
    }
}
