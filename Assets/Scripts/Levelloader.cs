using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levelloader : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void retryGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Level 1 Start");
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit..");
    }
}
