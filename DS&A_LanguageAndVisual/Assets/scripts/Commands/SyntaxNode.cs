using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    
    public class SyntaxNode {

        SyntaxNode parent;

        //For loops when they hit leaf, then go back to scope and execute that, later on will also be used for functions and the like
        BlockNode scope;
        //At most 2, because not possible to diverge to two different blocknodes at the same level
        //either continue with current body or transition into new one
        SyntaxNode[] children;

        
       
        public SyntaxNode()
        {
            children = new SyntaxNode[2];
        }
    }
}