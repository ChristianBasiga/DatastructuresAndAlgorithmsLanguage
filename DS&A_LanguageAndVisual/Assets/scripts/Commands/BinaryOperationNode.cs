using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{ 

    //Todo: Finish binary operations and test the operate iwth new keyword

    public class BinaryOperationNode : SyntaxNode
    {
        //For now just int as operands, 
        Variable<int> operand1;
        Variable<int> operand2;
        string theOperator;


        public void operate()
        {

        }
    }
}