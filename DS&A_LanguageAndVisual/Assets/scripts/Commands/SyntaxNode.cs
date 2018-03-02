using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    public class SyntaxNode {

        SyntaxNode parent;
        //At most 2, because not possible to diverge to two different blocknodes at the same level
        //either continue with current body or transition into new one
        SyntaxNode[] children;
       
        public SyntaxNode()
        {
            children = new SyntaxNode[2];
        }
    }
}