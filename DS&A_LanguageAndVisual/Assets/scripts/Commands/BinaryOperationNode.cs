using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.Util;
namespace DataStructureLanguage.Syntax.SyntaxNodes
{ 

    //Todo: Finish binary operations and test the operate iwth new keyword

    public class BinaryOperationNode : SyntaxNode
    {
        //For now just int as operands, 
        protected Variable operand1;
        protected Variable operand2;
        protected string theOperator;


        public bool operate()
        {
            return true;
        }
    }
}