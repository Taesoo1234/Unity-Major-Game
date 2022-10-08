using UnityEngine;
using UnityEngine.AI;

public class EnemyNavmesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        agent.destination = movePositionTransform.position;
        
    }
}