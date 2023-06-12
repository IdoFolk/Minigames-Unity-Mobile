using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdoPlayer : MonoBehaviour
{

    [SerializeField] Rigidbody2D body;


    float moveSpeed = 7f;
    public void Update()
    {
        
        transform.Rotate(0f, 0f, 100 * Time.deltaTime, Space.Self);
        
    }

    public void Foward()
    {
        transform.Rotate(0f, 0f, -100 * Time.deltaTime, Space.Self);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);

    }



}
