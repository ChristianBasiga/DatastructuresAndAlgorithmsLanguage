using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class ForLoopNode : BlockNode, IConditional
    {
        int counter;
        int reps;
        string type;


        public ForLoopNode()
        {
            type = "for";
        }


        public ForLoopNode(int reps)
        {
            this.reps = reps;
            counter = 0;
            type = "loop";
        }

        public int Reps
        {
            get
            {
                return reps;
            }
            set
            {
                reps = value;
            }
        }

        //Can just keep re-using didPass, I'm retarded yo.
        public bool didPass()
        {
            bool result = reps < counter;
            reps += 1;
            return result;
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

    }
}
