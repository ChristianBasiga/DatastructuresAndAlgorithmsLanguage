using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;
namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class AssignmentNode : BinaryOperationNode
    {
        public AssignmentNode()
        {

        }


        public override void execute(DataStructureLanguage.Syntax.Util.SyntaxTree programToLookIn)
        {
            //Prob best as coroutine tbh
            OnBeginExecuting();

            Variable two;
            int res;

            IsExecuting();
            //Here check if the strings are numeric, if they are then just number, otherwise check for variable name in dictionary.
            try
            {
                //   one = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(firstOperand, programToLookIn);
                two = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(secondOperand, programToLookIn);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            //That's it for now
            if (int.TryParse(firstOperand, out res))
            {

                throw new KeyNotFoundException("You cannot assign to a literal");
            }
            //Two variable doesn't matter if literal or variable
            if (programToLookIn.variables.ContainsKey(firstOperand))
            {
                programToLookIn.variables[firstOperand].Value = two.Value;
            }
            else
            {
                programToLookIn.variables[firstOperand] = new Variable(firstOperand);
                programToLookIn.variables[firstOperand].Value = two.Value;
            }

        }


    }
}