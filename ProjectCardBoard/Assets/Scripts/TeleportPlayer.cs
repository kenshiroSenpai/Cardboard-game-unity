using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
    public float timeLeft;
    public GameObject player;
    public Text cubeTextUI;
    public Button nextLevel;
    private bool teleport;
    private bool goal;
    private Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        teleport = false;
        goal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (teleport)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Teleport();
            }
        }

        if (goal)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Teleport();
                if (currentScene.name.Equals("Tutorial"))
                {
                    nextLevel.gameObject.SetActive(true);
                    cubeTextUI.text = "Good Job, You are ready to play :)";
                }
                else
                {
                    nextLevel.gameObject.SetActive(true);
                }
            }
        }
    }

    private void Teleport()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f,
                    transform.position.z);
    }

    public void PlayerUseTeleport()
    {
        teleport = true;
    }

    public void TeleportGoal()
    {
        goal = true;
    }

    public void ResetTime()
    {
        teleport = false;
        timeLeft = 0.6f;
    }
}
