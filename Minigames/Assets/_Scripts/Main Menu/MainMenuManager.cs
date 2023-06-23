using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] PlayMenuManager playMenu;
    public void PlayMenu()
    {
        gameObject.SetActive(false);
        playMenu.gameObject.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

}
