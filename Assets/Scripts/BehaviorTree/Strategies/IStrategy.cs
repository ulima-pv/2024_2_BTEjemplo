using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  ULima.BehaviorTree
{
        public interface IStrategy
        {
                Node.Status Process();
                void Reset();
        }
}
