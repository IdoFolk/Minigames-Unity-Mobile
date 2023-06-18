using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        if (FlappyBirdMiniGameManager.isPaused) return;
        transform.Translate(Vector3.left * Time.deltaTime*speed);
    }
    private void OnBecameInvisible()
    {
        ((FlappyBirdMiniGameManager)MiniGameManager.instace).ObstaclePullManager.Despawn(this);
    }
    private void OnEnable()
    {
        transform.localPosition = new Vector3(0,Random.Range(-2.5f,2.5f),0);
    }
}
