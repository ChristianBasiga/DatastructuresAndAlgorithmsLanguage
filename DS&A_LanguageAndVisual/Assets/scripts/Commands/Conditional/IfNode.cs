using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class IfNode : BlockNode, IConditional
    {
        protected Variable firstOperand;
        protected Variable secondOperand;
        protected string operation;
        protected string type;


        public IfNode()
        {
            type = "if";
        }

        public IfNode(Variable first, Variable second, string operation)
        {
            firstOperand = first;
            secondOperand = second;
            this.operation = operation;
            type = "If";
        }


        public Variable FirstOperand
        {
            get
            {
                return firstOperand;
            }
            set
            {
                firstOperand = value;
            }

        }
        public Variable SecondOperand
        {
            get
            {
                return secondOperand;
            }
            set
            {
                secondOperand = value;
            }
        }


        public void SetOperator(string operation)
        {
            this.operation = operation;
        }

        public bool didPass()
        {
            return Operators.logicalOperations[operation](firstOperand, secondOperand);
        }

        public string Type
        {
            get
            {
                return type;
            }
        }
    }
}
