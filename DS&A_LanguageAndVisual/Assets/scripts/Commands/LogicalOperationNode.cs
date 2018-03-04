using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;


namespace DataStructureLanguage.Syntax.SyntaxNodes {

    public delegate bool LogicalOperation(Variable a, Variable b);

   

    public abstract class LogicalOperationNode : BinaryOperationNode{

       
        public bool operate()
        {
            return Operators.logicalOperations[theOperator](operand1,operand2);
        }
    
    }
}