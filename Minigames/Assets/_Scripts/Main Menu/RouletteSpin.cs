using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class RouletteSpin : MonoBehaviour
{
    static public string SceneToLoad;
    bool isRotating = false;

    [SerializeField] Rigidbody2D rb;
    public void SpinWheel()
    {
        rb.AddTorque(Random.Range(1000, 1500));
    }
    private void Update()
    {
        if (rb.angularVelocity!=0) isRotating = true;
        if (isRotating && rb.angularVelocity == 0)
        {
            isRotating=false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
        }
    }
}
