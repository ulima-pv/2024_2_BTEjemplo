using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ULima.BehaviorTree
{
    public class ActionStrategy : IStrategy
    {
        private readonly Action m_Action;

        public ActionStrategy(Action action)
        {
            m_Action = action;
        }

        public Node.Status Process()
        {
            m_Action();
            return Node.Status.Success;
        }

        public void Reset()
        {}
    }
}
