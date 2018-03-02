using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util.Variable;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{

    //Not really needed anymore cause node's don't have bodies just traversing tree
    public class BlockNode 
    {
    
        Dictionary<string, Variable<int>> environVariables;
      
        public void addVariable(string varname, Variable<int> variable)
        {
            environVariables[varname] = variable;
        }
    }
}