using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ULima.BehaviorTree
{
    public class ConditionStrategy : IStrategy
    {
        private readonly Func<bool> m_Predicate;

        public ConditionStrategy(Func<bool> predicate)
        {
            m_Predicate = predicate;
        }

        public Node.Status Process()
        {
            return m_Predicate() ? Node.Status.Success : Node.Status.Failure;
        }

        public void Reset()
        {}
    }
}
