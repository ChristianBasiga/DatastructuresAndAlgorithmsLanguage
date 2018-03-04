using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class ForLoopNode : BlockNode, ILoop
    {
        int counter;
        int reps;

        public ForLoopNode(int reps)
        {
            this.reps = reps;
            counter = 0;
        }

        public bool isDone()
        {
            return counter >= reps;
        }
    }
}
