using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    void Update()
    {
        if(player != null)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player);
       
        }
    }
}
