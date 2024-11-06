using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ULima.BehaviorTree
{
    public class Node
    {
        public enum Status { Success, Failure, Running }

        public readonly string nodeName;
        public readonly List<Node> children;
        protected int m_CurrentChild = 0;

        public Node(string name)
        {
            nodeName = name;
            children = new();
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }

        public virtual Status Process()
        {
            return children[m_CurrentChild].Process();
        }
        public virtual void Reset()
        {
            foreach (var child in children)
            {
                child.Reset();
            }
            m_CurrentChild = 0;
        }
    }
}
