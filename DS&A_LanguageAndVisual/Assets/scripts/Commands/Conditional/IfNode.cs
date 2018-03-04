using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class IfNode : BlockNode, IConditional
    {
        Variable firstOperand;
        Variable secondOperand;
        string operation;

        public IfNode(Variable first, Variable second, string operation)
        {
            firstOperand = first;
            secondOperand = second;
            this.operation = operation;
        }

        public bool didPass()
        {
            return Operators.logicalOperations[operation](firstOperand, secondOperand);
        }

    }
}
