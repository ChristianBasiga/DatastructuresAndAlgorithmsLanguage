using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    public class IfElseNode : LogicalOperationNode {

        SyntaxNode elseBody;

        public SyntaxNodes Else
        {
            get
            {
                return elseBody;
            }
        }
    }
}