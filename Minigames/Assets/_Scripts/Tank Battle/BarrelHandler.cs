using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Transform explosionParent;
    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity, explosionParent);
    }
}
