using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandeler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
    }
}
