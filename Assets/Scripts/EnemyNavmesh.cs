using UnityEngine;
using UnityEngine.AI;

public class EnemyNavmesh : MonoBehaviour
{
    // serialize the script, create a private tranform called "movePositionTransform"
    [SerializeField] private Transform movePositionTransform;

    // create a private NavMeshAgent called "agent"
    private NavMeshAgent agent;

    // when the script is loaded
    private void Awake()
    {
        // obtain the NavMeshAgent component and call it "agent"
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        // move toward the destination
        agent.destination = movePositionTransform.position;
        
    }
}