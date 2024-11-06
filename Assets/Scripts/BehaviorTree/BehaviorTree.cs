using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  ULima.BehaviorTree
{
    public class BehaviorTree : Node
    {
        public BehaviorTree(string name = "Behavior Tree") : base(name)
        {}

        public override Status Process()
        {
            while(m_CurrentChild < children.Count)
            {
                var status = children[m_CurrentChild].Process();
                if (status != Status.Success)
                {
                    return status;
                }
                m_CurrentChild++;
            }
            Reset();
            return Status.Success;
        }
    }
}
