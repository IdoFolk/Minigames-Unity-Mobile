using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouletteSlot : MonoBehaviour
{
    [SerializeField] string SceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(SceneToLoad);
        RouletteSpin.SceneToLoad = SceneToLoad;
    }
}
