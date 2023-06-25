using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] int _number;
    [SerializeField] MiniGameManager miniGameManager;

    public void ChangeText()
    {
        text.text = _number.ToString();
        Debug.Log("Change");
    }
    public void End()
    {
        Destroy(gameObject);
        miniGameManager.StartScene();
    }
   
}
