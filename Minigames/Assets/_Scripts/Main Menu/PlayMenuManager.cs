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
    public void PlayFlappyBirdGame()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayRandomGame()
    {
        int rand = Random.Range(1, 3);
        SceneManager.LoadScene(rand);
    }
}
