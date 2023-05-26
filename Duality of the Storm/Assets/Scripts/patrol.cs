using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    float patrolRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(RandomNavmeshLocation(patrolRadius));

    }

    private void Update()
    {
        if (agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
            agent.SetDestination(RandomNavmeshLocation(patrolRadius));
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector2 randomDirection = Random.insideUnitCircle * radius;
        randomDirection.x += transform.position.x;
        randomDirection.y += transform.position.z;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(new Vector3(randomDirection.x, 0f, randomDirection.y), out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
