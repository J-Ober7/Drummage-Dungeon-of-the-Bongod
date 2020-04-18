using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public enum States
    {
        Patrol, Chase, InBattle
    }

    public States state;
    public Vector3[] destinations;
    public float speed;
    public int index;
    public Vector3 currentDes;
    private NavMeshAgent nma;
    public Animator anim;
    public GameObject player;
    public float ChaseDistance;
    private float distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Patrol;
        index = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        nma = GetComponent<NavMeshAgent>();

        for(int i = 0; i < destinations.Length; ++i)
        {
            destinations[i] = transform.position + destinations[i];
        }

        currentDes = destinations[index];
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch(state)
        {
            case States.Chase:
                Chase();
                break;
            case States.Patrol:
                Patrol();
                break;
            case States.InBattle:
                InBattle();
                break;
            default:
                break;

        }
    }

    private void InBattle()
    {
        nma.speed = 0;
        anim.SetInteger("State", 0);
        currentDes = transform.position;
    }

    private void Patrol()
    {
        nma.speed = speed;
        anim.SetInteger("State", 2);

        if (Vector3.Distance(transform.position, currentDes) < 1)
        {
            NextPoint();
        }
        else if (distanceToPlayer <= ChaseDistance)
        {
            state = States.Chase;
        }

        Vector3 lookat = currentDes;
        lookat.y = transform.position.y;
        transform.LookAt(lookat);
        nma.SetDestination(currentDes);
    }

    private void NextPoint()
    {
        currentDes = destinations[index];
        nma.SetDestination(currentDes);

        index = (index + 1) % destinations.Length;
    }

    private void Chase()
    {
        anim.SetInteger("State", 1);
        nma.stoppingDistance = 3;
        nma.speed = speed;

        if(distanceToPlayer > ChaseDistance)
        {
            state = States.Patrol;
        }

        currentDes = player.transform.position;
        Vector3 lookat = currentDes;
        lookat.y = transform.position.y;
        transform.LookAt(lookat);
        nma.SetDestination(currentDes);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            state = States.InBattle;
        }
    }
}
