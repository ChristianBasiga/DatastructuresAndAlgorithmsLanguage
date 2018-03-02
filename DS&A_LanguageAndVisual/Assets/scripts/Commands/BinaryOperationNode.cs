using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public abstract class BinaryOperationNode : SyntaxNode
    {
        //For now just int as operands, 
        Variable<int> operand1;
        Variable<int> operand2;
        string theOperator;
    }
}