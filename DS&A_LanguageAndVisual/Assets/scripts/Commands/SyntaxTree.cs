using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.Util
{
    public class SyntaxTree
    {
        DataStructureLanguage.Syntax.SyntaxNode root;
        DataStructureLanguage.Syntax.SyntaxNode current;

        //To go back to from previous body.
        Stack<DataStructureLanguage.Syntax.SyntaxNode> prevBodies;

        public SyntaxTree(DataStructureLanguage.Syntax.SyntaxNode root)
        {
            this.root = root;
            current = root;
        }

        public void traverseRight()
        {
            //ToDo: Go to right child of root, if returns true, push current node to stack, set new root to this.
            

        }

        public void traverseLeft()
        {
            //ToDo: These are nonblock nodes
        }
    }
}