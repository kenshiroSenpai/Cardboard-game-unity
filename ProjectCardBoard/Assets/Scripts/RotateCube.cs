using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{

    public float spinForce;
    private float oldSpin;

    private void Start()
    {
        oldSpin = spinForce;
    }

    private void Update()
    {
        transform.Rotate(0, spinForce * Time.deltaTime, 0);
    }

    public void StopSpin()
    {
        spinForce = 0.0f;
    }

    public void ResumeSpin()
    {
        spinForce = oldSpin;
    }
}
