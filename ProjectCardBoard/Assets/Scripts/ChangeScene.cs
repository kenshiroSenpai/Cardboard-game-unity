using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public float timeLeft;
    private bool changeScene;
    private bool quitGame;
    private string sceneName;

    private void Start()
    {
        timeLeft = 0.6f;
    }

    private void Update()
    {
        if (changeScene)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene(sceneName);
                changeScene = false;
            }
        }

        if (quitGame)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Application.Quit();
            }
        }

    }

    public void GoToScene(string scene)
    {
        sceneName = scene;
        changeScene = true;
    }

    public void QuitGame()
    {
        quitGame = true;
    }

    public void ResetTime()
    {
        changeScene = false;
        quitGame = false;
        timeLeft = 0.6f;
    }
}
