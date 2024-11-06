using System.Collections;
using System.Collections.Generic;
using ULima.BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStrategy : IStrategy
{
    private readonly Transform m_Destination;
    private readonly NavMeshAgent m_Agent;

    public PatrolStrategy(Transform destination, NavMeshAgent agent)
    {
        m_Destination = destination;
        m_Agent = agent;
    }

    public Node.Status Process()
    {
        if (m_Agent.pathEndPosition == m_Destination.position)
        {
            return Node.Status.Success;
        }
        m_Agent.SetDestination(m_Destination.position);
        return Node.Status.Running;
    }

    public void Reset()
    {}
}
