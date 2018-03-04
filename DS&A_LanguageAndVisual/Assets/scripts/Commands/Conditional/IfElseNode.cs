using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    //I was being retarded lsat night, Logical OperationNodes is some IfElseNodes HAVE has-a relationship not is-a
    public class IfElseNode  : BlockNode {

        LogicalOperationNode condition;

        SyntaxNode elseBody;

        

        public SyntaxNode Else
        {
            get
            {
                return elseBody;
            }
        }


    }
}