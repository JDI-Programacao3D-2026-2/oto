using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;


public class EnemyNavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform[] waypoints;

    public LayerMask layerMask;

    public enum EnemyState
    {
        Waypatrol, RandomPatrol, Pursuit
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

    void Pursuit()
    {
        if (player != null)
        {
            agent.stoppingDistance = 6f;
            agent.SetDestination(player.position);
            transform.LookAt(player);
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
        }

        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20f, layerMask))
        {
            ChangeState(EnemyState.Pursuit);
        }
        else
        {
            ChangeState(EnemyState.Waypatrol);
        }
    }
}
