using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
