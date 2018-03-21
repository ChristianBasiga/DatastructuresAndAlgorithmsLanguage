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
        protected ConditionalType type; 

        public IfNode()
        {
            type = ConditionalType.IF;
        }

        public ConditionalType Type
        {
            get
            {
                return type;
            }
        }

       

        public void SetCondition(BinaryOperationNode condition)
        {
            this.condition = condition;
        }
        //Unless instead of attribute, I just pass in the SyntaxTree so it knows where to look, that way I could possible reuse nodes. That might be better
        public bool didPass(DataStructureLanguage.Syntax.Util.SyntaxTree syntaxTree)
        {

            //These event starts only need to be here cause all share same didPass method
            OnBeginExecuting();
      //      IsExecuting();

            //These meant to be temporary variables just to hold either the number or variable stored in SyntaxTree, and this way I can just move logic to function to avoid
            //duplicate code
            Variable one, two;

            //Here check if the strings are numeric, if they are then just number, otherwise check for variable name in dictionary.
            try
            {
                one = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(condition.FirstOperand, syntaxTree);
                two = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(condition.SecondOperand, syntaxTree);
            }
            catch (System.Exception e)
            {
                throw e;
            }


            

            //Does actual operation, returning the result. Todo: Do same in assignment node.
            return Operators.logicalOperations[condition.Operation](one, two);
        }

     
    }
}
