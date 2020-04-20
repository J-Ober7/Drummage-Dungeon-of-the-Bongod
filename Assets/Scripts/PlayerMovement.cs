using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public LayerMask lm;

    private Collider coll;
    private bool forward, backward;

    public float rotationAmount = 50.0f;
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
        if (!LevelController.inCombat) {
            if (Input.GetButtonDown("Forward") && !forward && targetAngle == 0) {
                transform.position += transform.forward * speed;
            }

            if (Input.GetButtonDown("Backward") && !backward && targetAngle == 0) {
                transform.position -= transform.forward * speed;
            }

            if (Input.GetButtonDown("Left")) {
                targetAngle -= 90;
            }

            if (Input.GetButtonDown("Right")) {
                targetAngle += 90;
            }

            if (targetAngle != 0) {
                Rotate();
            }
        }
    }

    protected void Rotate()
    {

        float step = rotationAmount * Time.deltaTime;

        if (targetAngle > 0)
        {
            if(targetAngle - step < 0) {
                step = targetAngle;
            }
            transform.Rotate(Vector3.up * step);
            targetAngle -= step;
            /*if(targetAngle < 1)
            {
                targetAngle = 0;
            }*/
        }
        else if (targetAngle < 0)
        {
            if (targetAngle + step > 0) {
                step = -1 * targetAngle;
            }
            transform.Rotate(Vector3.up * -1 * step);
            targetAngle += step;

            /*if (targetAngle > -1)
            {
                targetAngle = 0;
            }*/
        }
    }
    public void resetTarget() 
    {
        targetAngle = 0;
    }
    private void UpdateRays()
    {
        Vector3 center = coll.bounds.center;
        float offset = coll.bounds.extents.z;
        Vector3 forpos = center + transform.forward * offset;
        Vector3 backpos = center - transform.forward * offset;

        forward = Physics.Raycast(forpos, transform.forward, speed, lm);
        backward = Physics.Raycast(backpos, transform.forward * -1, speed, lm);

        Debug.DrawRay(forpos, transform.forward * speed, Color.yellow);
        Debug.DrawRay(backpos, transform.forward * -1 * speed, Color.red);
    }

    private void ResetRays()
    {
        forward = backward = false;
    }
}
