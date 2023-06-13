using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    public void Thrust()
    {
        if (body.velocity.y < 10)
        {
            body.AddForce(new(0, 5));
        }
    }
}
