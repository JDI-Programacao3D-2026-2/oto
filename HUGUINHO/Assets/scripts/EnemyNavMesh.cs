using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class EnemyNavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform[] waypoints;

    public LayerMask layerMask;
    public float losePlayerDistance = 15f; 


    public enum EnemyState
    {
        Waypatrol, RandomPatrol, Pursuit, Run
    }

    public EnemyState currentState = EnemyState.Waypatrol;

    void Update()
    {
        FiniteStateMachine();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    void FiniteStateMachine()
    {
        switch (currentState)
        {
            case EnemyState.Pursuit:
                Pursuit();
                break;

            case EnemyState.Waypatrol:
                WayPatrol();
                break;

            case EnemyState.Run:
                Run();
                break;
        }

      
    }

    void Pursuit()
    {
        if (player != null)
        {
            agent.stoppingDistance = 6f;
            agent.SetDestination(player.position);
            transform.LookAt(player);
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > losePlayerDistance)
        {
            ChangeState(EnemyState.Waypatrol);
        }
    }

    void WayPatrol()
    {
        agent.stoppingDistance = 0f;
        if (waypoints.Length != 0 && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            int randomIndex = UnityEngine.Random.Range(0, waypoints.Length);
            agent.SetDestination(waypoints[randomIndex].position);
        }
        SearchPlayer();
    }

    void SearchPlayer()
    {

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20f, layerMask))
        {
            ChangeState(EnemyState.Pursuit);
        }
        else
        {
           CallBackup();
        }
    }
     

    void CallBackup()
    {
        EnemyNavMesh[] todosInimigos = FindObjectsByType<EnemyNavMesh>();
        foreach (EnemyNavMesh aliado  in todosInimigos)
        {

            float distancia = Vector3.Distance(transform.position, aliado.transform.position);
            if (distancia < 10f)
            {
                aliado.ChangeState(EnemyState.Pursuit);
            }
        }


    }

    void Run()
    {

    }

}
