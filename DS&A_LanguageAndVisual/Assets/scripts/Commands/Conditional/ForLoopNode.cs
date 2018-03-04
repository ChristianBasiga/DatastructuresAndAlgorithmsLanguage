using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class ForLoopNode : BlockNode, IConditional
    {
        int counter;
        int reps;

        public ForLoopNode(int reps)
        {
            this.reps = reps;
            counter = 0;
        }

        //Can just keep re-using didPass, I'm retarded yo.
        public bool didPass()
        {
            bool result = reps < counter;
            reps += 1;
            return result;
        }
    }
}
