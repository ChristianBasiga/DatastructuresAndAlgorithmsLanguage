using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class WhileLoopNode : BlockNode,ILoop,IConditional
    {


        LogicalOperationNode condition;

        public bool isDone()
        {
            return !didPass();
        }

        public bool didPass()
        {
            return condition.operate();

        }
    }
}