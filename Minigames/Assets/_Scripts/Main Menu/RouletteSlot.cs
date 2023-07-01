using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouletteSlot : MonoBehaviour
{
    [SerializeField] SceneAsset SceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RouletteSpin.SceneToLoad = SceneToLoad.name;
    }
}
