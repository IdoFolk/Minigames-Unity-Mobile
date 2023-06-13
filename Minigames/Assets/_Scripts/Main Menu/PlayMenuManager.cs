using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuManager : MonoBehaviour
{
    public void PlaySpaceshipGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayRandomGame()
    {
        int rand = Random.Range(1, 2);
        SceneManager.LoadScene(rand);
    }
}
