using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;
namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class AssignmentNode : BinaryOperationNode, IExecute
    {
        public AssignmentNode()
        {

        }


        public void execute(DataStructureLanguage.Syntax.Util.SyntaxTree programToLookIn)
        {
            //Prob best as coroutine tbh
            OnBeginExecuting();

            Variable one, two;


            IsExecuting();
            //Here check if the strings are numeric, if they are then just number, otherwise check for variable name in dictionary.
            try
            {
                one = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(firstOperand, programToLookIn);
                two = DataStructureLanguage.Syntax.Util.UtilMethods.ValidateOperand(secondOperand, programToLookIn);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            //Could make it "literal" instead but eh. Plus then it would make literal be unable to be used as name for a variable
            if (one.name == null)
            {
                throw new KeyNotFoundException("You cannot assign to a literal");
            }
            else if (operation == "=")
            {
                //That's it for now
                //Two variable doesn't matter if literal or variable
                programToLookIn.variables[firstOperand].Value = two.Value;

                //Because one is referencing the variable already inside the dictionary.
                one.Value = two.Value;
            }

            OnDoneExecuting();

        }

      
    }
}