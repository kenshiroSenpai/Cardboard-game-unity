using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed;
    private bool left, right;

    private void Start()
    {
        left = false;
        right = true;
    }

    void Update()
    {
        if (left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("GoLeft"))
        {
            left = true;
            right = false;
        }

        if (collision.collider.tag.Equals("GoRight"))
        {
            right = true;
            left = false;
        }
    }
}
