using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{

    //Not really needed anymore cause node's don't have bodies just traversing tree
    //Should I ahv type here? feel like
    public class BlockNode : SyntaxNode
    {
    
        Dictionary<string, Variable> environVariables;
      
        public void addVariable(string varname, Variable variable)
        {
            environVariables[varname] = variable;
        }
    }
}