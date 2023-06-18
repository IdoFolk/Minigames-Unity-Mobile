using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePullManager : MonoBehaviour
{
    Queue<ObstacleScript> obstacleScripts;

    private void Awake()
    {
        obstacleScripts = new(GetComponentsInChildren<ObstacleScript>(true));
    }
    public void Spawn()
    {
        obstacleScripts.Dequeue().gameObject.SetActive(true);
    }
    public void Despawn(ObstacleScript obst)
    {
        Debug.Log("Why");
        obst.gameObject.SetActive(false);
        obst.transform.position = transform.position;
        obstacleScripts.Enqueue(obst);
    }
}
