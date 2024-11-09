using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ULima.BehaviorTree
{
    public class Selector : Node
    {
        public Selector(string name) : base(name)
        {}

        public override Status Process()
        {
            if (m_CurrentChild < children.Count)
            {
                switch(children[m_CurrentChild].Process())
                {
                    case Status.Running:
                        return Status.Running;
                    case Status.Success:
                        Reset();
                        return Status.Success;
                    default:
                        m_CurrentChild++;
                        return Status.Running;
                }
            }
            Reset();
            return Status.Failure;
        }
    }
}
