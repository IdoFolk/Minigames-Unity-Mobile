using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] GameObject TitleName;
    [SerializeField] GameObject MadeBy;
    [SerializeField] PlayMenuManager playMenu;
    [SerializeField] GameObject PlayButton;
    public void PlayMenu()
    {
        gameObject.SetActive(false);
        playMenu.gameObject.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void Start()
    {

        MadeBy.transform.DOMoveX(transform.position.x ,2.5f);
        PlayButton.transform.DOPunchRotation(new(0, 0, 360), 2f);
    }
    public void RotateTitleScreen()
    {
        TitleName.transform.DOPunchScale(transform.localScale,1f);
    }

}
