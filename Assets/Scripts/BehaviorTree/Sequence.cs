using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ULima.BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence(string name) : base(name)
        {}

        public override Status Process()
        {
            if (m_CurrentChild < children.Count)
            {
                switch(children[m_CurrentChild].Process())
                {
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        Reset();
                        return Status.Failure;
                    default:
                        m_CurrentChild++;
                        return m_CurrentChild == children.Count ?
                            Status.Success :
                            Status.Running; 
                }
            }
            Reset();
            return Status.Success;
        }
    }
}
