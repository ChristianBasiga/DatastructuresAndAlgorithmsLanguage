using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class AssignmentNode : SyntaxNode
    {

        //similiar to If but doesn't implement IConditional
        
        Variable operand1;
        Variable operand2;
        string operation;
        // Use this for initializatio


        public AssignmentNode()
        {

        }

        public Variable Operand1 { get { return operand1; } set { operand1 = value; } }
        public Variable Operand2 { get { return operand2; } set { operand2 = value; } }
        public string Operation { get { return operation; } set { operation = value; } }
    }
}