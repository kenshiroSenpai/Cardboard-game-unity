using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTeleport : MonoBehaviour
{
    public GameObject teleport;
    public GameObject cube;
    public GameObject ball;

    void Start()
    {
        teleport.transform.SetParent(cube.transform);

    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Ball"))
        {
            teleport.transform.SetParent(null);
        }
    }
}
