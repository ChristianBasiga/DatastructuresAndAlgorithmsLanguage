using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class ForLoopNode : LogicalOperationNode, ILoop
    {
        int counter;
        int reps;

        public ForLoopNode(int reps)
        {
            this.reps = reps;
            counter = 0;
        }

        bool isDone()
        {
            return counter >= reps;
        }
    }
}
