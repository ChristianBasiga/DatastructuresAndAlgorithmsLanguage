using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;

    namespace DataStructureLanguage.Syntax.SyntaxNodes { 

    //I was being retarded lsat night, Logical OperationNodes is some IfElseNodes HAVE has-a relationship not is-a
    public class IfElseNode : IfNode {


        public SyntaxNode elseBody;

        public IfElseNode()
        {
            type = ConditionalType.IFELSE;
        }

      

        public SyntaxNode Else
        {
            get
            {
                return elseBody;
            }
            set
            {
                elseBody = value;
            }
        }

    }
}