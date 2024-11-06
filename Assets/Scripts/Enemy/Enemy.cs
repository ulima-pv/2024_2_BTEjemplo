using System;
using System.Collections;
using System.Collections.Generic;
using ULima.BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypoint;

    private NavMeshAgent m_Agent;

    private BehaviorTree m_Bt;
    private void Awake() 
    {
        m_Agent = GetComponent<NavMeshAgent>();

        CreateBT();
    }
    private void Update() 
    {
        m_Bt.Process();
    }

    private void CreateBT()
    {
        m_Bt = new BehaviorTree("Arbol Ejemplo");

        var leaf = new Leaf(
            "Patrullaje", 
            new PatrolStrategy(waypoint, m_Agent)
        );

        m_Bt.AddChild(leaf);
    }
}
