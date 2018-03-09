using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    //Different, but still share same interface, sucks that duplicating this, but assignments aren't blocks
    //I could make it so this one has a BinaryOperationNode, which would make sense
    public class IfNode : BlockNode, IConditional
    {
        protected BinaryOperationNode condition;


        public IfNode()
        {
            type = "if";
        }

        public IfNode(string first, string second, string operation)
        {
            firstOperand = first;
            secondOperand = second;
            this.operation = operation;
            type = "If";
        }

        public void SetCondition(BinaryOperationNode condition)
        {
            this.condition = condition;
        }
        //Unless instead of attribute, I just pass in the SyntaxTree so it knows where to look, that way I could possible reuse nodes. That might be better
        public bool didPass(DataStructureLanguage.Syntax.Util.SyntaxTree syntaxTree)
        {
            //These meant to be temporary variables just to hold either the number or variable stored in SyntaxTree, and this way I can just move logic to function to avoid
            //duplicate code
            Variable one, two;

            //Here check if the strings are numeric, if they are then just number, otherwise check for variable name in dictionary.
            try
            {
                one = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(firstOperand, syntaxTree);
                two = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(secondOperand, syntaxTree);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            //Does actual operation, returning the result. Todo: Do same in assignment node.
            return Operators.logicalOperations[operation](one, two);
        }

        //Move this to util
       
        public string Type
        {
            get
            {
                return type;
            }
        }
    }
}
