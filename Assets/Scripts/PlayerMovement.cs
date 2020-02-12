using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public LayerMask lm;

    private Collider coll;
    private bool forward, backward;

    private float rotationAmount = 4.0f;
    private float targetAngle = 0.0f;


    private void Start()
    {
        coll = gameObject.GetComponent<Collider>();
        ResetRays();

    }

    // Update is called once per frame
    void Update()
    {
        ResetRays();
        UpdateRays();

        if (Input.GetButtonDown("Forward") && !forward)
        {
            transform.position += transform.forward * speed;
        }

        if (Input.GetButtonDown("Backward") && !backward)
        {
            transform.position -= transform.forward * speed;
        }

        if (Input.GetButtonDown("Left"))
        {
            targetAngle -= 90;
        }

        if(Input.GetButtonDown("Right"))
        {
            targetAngle += 90;
        }

        if (targetAngle != 0)
        {
            Rotate();
        }
    }

    private void UpdateRays()
    {
        Vector3 center = coll.bounds.center;
        float offset = coll.bounds.extents.z;
        Vector3 forpos = center + transform.forward * offset;
        Vector3 backpos = center - transform.forward * offset;

        forward = Physics.Raycast(forpos, transform.forward, speed / 2, lm);
        backward = Physics.Raycast(backpos, transform.forward * -1, speed / 2, lm);

        Debug.DrawRay(forpos, transform.forward, Color.yellow);
        Debug.DrawRay(backpos, transform.forward * -1, Color.red);
    }

    private void ResetRays()
    {
        forward = backward = false;
    }

    protected void Rotate()
    {

        float step = rotationAmount * Time.deltaTime;

        if (targetAngle > 0)
        {
            transform.Rotate(Vector3.up * rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.Rotate(Vector3.up * -rotationAmount);
            targetAngle += rotationAmount;
        }

    }
}
