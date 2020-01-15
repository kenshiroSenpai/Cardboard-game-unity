using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerGrab : MonoBehaviour
{
    private GameObject[] arrayBalls;
    private Rigidbody rbBall;
    public GameObject MyHands;
    public float timeLeft;
    private bool entered;
    public bool inHands;
    public Text textBallUI;
    public Text textCubeUI;
    private Scene currentScene;
    public int balls;
    public int order;

    private void Start()
    {

        order = 0;
        arrayBalls = GameObject.FindGameObjectsWithTag("Ball").OrderBy(o => o.name).ToArray();
        balls = GameObject.FindGameObjectsWithTag("Ball").Length;
        currentScene = SceneManager.GetActiveScene();
        entered = false;
        inHands = BallInHands(false);
    }

    private void Update()
    {
        if (balls > 0)
        {
            if (entered && !inHands)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    arrayBalls[order].transform.SetParent(MyHands.transform);
                    arrayBalls[order].transform.localPosition = new Vector3(0, -0.5f, 0.75f);
                    rbBall.useGravity = false;
                    rbBall.velocity = Vector3.zero;
                    if (currentScene.name.Equals("Tutorial"))
                    {
                        textBallUI.gameObject.SetActive(false);
                        textCubeUI.gameObject.SetActive(true);
                    }
                    entered = false;
                    inHands = BallInHands(true);
                }
            }
        }
    }

    public void GrapBall()
    {
        if (balls > 0)
        {
            rbBall = arrayBalls[order].GetComponent<Rigidbody>();
            entered = true;
        }
    }

    public void ResetTime()
    {
        entered = false;
        timeLeft = 0.6f;
    }

    private bool BallInHands(bool status)
    {
        return status;
    }
}
