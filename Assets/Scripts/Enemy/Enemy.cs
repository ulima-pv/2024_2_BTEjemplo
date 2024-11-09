using System;
using System.Collections;
using System.Collections.Generic;
using ULima.BehaviorTree;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public List<Transform> Waypoints;
    public Transform Target;
    public float DistanceToAttack = 2f;

    private NavMeshAgent m_Agent;

    private BehaviorTree m_Bt;

    private int m_CurrentWaypoint;

    private void Awake() 
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_CurrentWaypoint = 0;

        CreateBT();
    }
    private void Update() 
    {
        m_Bt.Process();
    }

    private void CreateBT()
    {
        m_Bt = new BehaviorTree("Arbol Patrullaje con Waypoints");

        var revisarCambioWaypointLeaf = new Leaf(
            "RevisarCambioWaypoint",
            new ConditionStrategy(() => {
                return !m_Agent.pathPending && m_Agent.remainingDistance < 0.1f;
            })
        );

        var patrullarLeaf = new Leaf(
            "PatrullarLeaf",
            new ActionStrategy(() => {
                m_Agent.SetDestination(Waypoints[m_CurrentWaypoint].position);
                
                m_CurrentWaypoint++;
                if (m_CurrentWaypoint == Waypoints.Count)
                {
                    m_CurrentWaypoint = 0;
                }
            })
        );

        var sequencePatrullaje = new Sequence("Secuencia Patrullaje");
        sequencePatrullaje.AddChild(revisarCambioWaypointLeaf);
        sequencePatrullaje.AddChild(patrullarLeaf);

        var sequenceAtaque = new Sequence("Secuencia Ataque");
        sequenceAtaque.AddChild(
            new Leaf(
                "ExisteEnemigoLeaf", 
                new ConditionStrategy(() => {
                    var distance = Vector3.Distance(Target.position, transform.position);
                    return distance < DistanceToAttack;
                })
            )
        );
        sequenceAtaque.AddChild(
            new Leaf(
                "AtaqueLeaf",
                new ActionStrategy(() => {
                    m_Agent.SetDestination(Target.position);
                    Debug.Log("Ataca");
                })
            )
        );

        var selector = new Selector("Comportamiento Enemigo");
        selector.AddChild(sequenceAtaque);
        selector.AddChild(sequencePatrullaje);

        m_Bt.AddChild(selector);
    }
}
