using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.PackageManager;
using UnityEngine;
namespace  ULima.BehaviorTree
{
    public class Leaf : Node
    {
        private IStrategy m_Strategy;

        public Leaf(string name, IStrategy strategy) : base(name)
        {
            m_Strategy = strategy;
        }

        public override Status Process()
        {
            return m_Strategy.Process();
        }
    }
}
