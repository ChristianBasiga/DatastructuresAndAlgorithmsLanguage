using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    
    public class SyntaxNode {

        SyntaxNode parent;

        //For loops when they hit leaf, then go back to scope and execute that, later on will also be used for functions and the like
        BlockNode scope;

        SyntaxNode left;
        SyntaxNode right;


        public SyntaxNode()
        {
        }

        public SyntaxNode getParent()
        {
            return parent;
        }

        public void setLeftChild(SyntaxNode child)
        {
            left = child;
        }

        public void setRightChild(BlockNode child)
        {
            right = child;
        }

        public SyntaxNode leftChild()
        {
            return left;
        }

        public BlockNode rightChild()
        {
            return (BlockNode)right;
        }


       
    }
}