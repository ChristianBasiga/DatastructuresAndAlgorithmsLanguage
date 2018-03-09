using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.Util
{
    public class UtilMethods
    {

        public static Variable ValidateOperand(string operand, DataStructureLanguage.Syntax.Util.SyntaxTree syntaxTree)
        {
            Variable vari = new Variable(null);
            int n;
            bool isNumeric = int.TryParse(operand, out n);

            try
            {
                //If not numberic, then must be variable or invalid.
                if (!isNumeric)
                {

                    if (!syntaxTree.variables.ContainsKey(operand))
                    {
                        throw new System.Exception(string.Format("The variable %s does not exist", operand));
                    }
                    else
                    {
                        //Change to point to actual variable instead
                        vari = syntaxTree.variables[operand];
                    }
                }
                else
                {
                    vari = new Variable(null);
                    vari.Value = n;
                }

            }
            catch (System.Exception e)
            {
                throw e;
            }
            return vari;
        }
    }
}