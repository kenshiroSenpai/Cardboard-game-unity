using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReleaseBall : MonoBehaviour
{
    private bool triggerEvent;
    public float timeLeft;
    public GameObject ball;
    public GameObject cube;
    public GameObject childObject;
    public Text textCubeUI;
    public Canvas canvaCube;
    public Rigidbody rbBall;
    public float force;
    public PlayerGrab player;
    public Camera playerCam;
    private Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (player.balls > 0)
        {
            if (triggerEvent)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    ball.transform.SetParent(null);
                    rbBall.useGravity = true;
                    rbBall.velocity = playerCam.transform.rotation * Vector3.forward * force;
                    triggerEvent = false;
                    player.inHands = false;
                }
            }
        }
    }

    public void ActiveEvent()
    {
        if (player.inHands)
        {
            triggerEvent = true;
        }
    }

    public void ResetTime()
    {
        triggerEvent = false;
        timeLeft = 0.6f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Ball"))
        {
            if (cube.transform.childCount > 0)
            {
                childObject.transform.SetParent(null);
            }
            Destroy(ball);
            Destroy(cube);
            player.balls--;
            player.order++;
            if (currentScene.name.Equals("Tutorial"))
            {
                textCubeUI.text = "Now, watch this cyan floor tile, if you want of course";
            }
        }
    }
}
