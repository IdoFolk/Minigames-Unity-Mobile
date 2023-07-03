using System.Collections.Generic;
using UnityEngine;

public class ObstaclePullManager : MonoBehaviour
{
    Queue<ObstacleScript> obstacleScripts;

    private void Awake()
    {
        obstacleScripts = new(GetComponentsInChildren<ObstacleScript>(true));
        //Unity doesn't Seriazlize Queue, sorry for GetComponent . _. 
    }
    public void Spawn()
    {
        obstacleScripts.Dequeue().gameObject.SetActive(true);
    }
    public void Despawn(ObstacleScript obst)
    {
        obst.gameObject.SetActive(false);
        obst.transform.position = transform.position;
        obstacleScripts.Enqueue(obst);
    }
}
