using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class WhileLoopNode : LogicalOperationNode,ILoop
    {
        bool isDone()
        {
            return !didPass();
        }
    }
}