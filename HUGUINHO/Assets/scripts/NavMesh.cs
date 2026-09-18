using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
