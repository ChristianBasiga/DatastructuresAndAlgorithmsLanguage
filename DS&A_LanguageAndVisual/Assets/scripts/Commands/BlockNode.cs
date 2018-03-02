using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util.Variable;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{

    //Not really needed anymore cause node's don't have bodies just traversing tree
    public class BlockNode 
    {
        //Block node will have it's own set of variables that are only in this environment
        //int to keep track of when it was created. Edit: Fuck it for now just hoist it, as long as it's been declared
        //it can be used.
        //Dictionary<int,>
        Dictionary<string, Variable<int>> environVariables;
      
        public void addVariable(string varname, Variable<int> variable)
        {
            environVariables[varname] = variable;
        }
    }
}