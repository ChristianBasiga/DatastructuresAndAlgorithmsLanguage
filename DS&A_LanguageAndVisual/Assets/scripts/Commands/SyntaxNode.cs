using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    //I suppose at this point might as well make this just have operands, but will leave like this for now can change easily later on
    
    //Not every syntax node executes, I could make it like this but it'll probably end up like my iOS project.
    public abstract class SyntaxNode {

        SyntaxNode parent;

        //For loops when they hit leaf, then go back to scope and execute that, later on will also be used for functions and the like
        BlockNode scope;
        SyntaxNode left;
        SyntaxNode right;


        //event handlers.
        public delegate void ExecutionEvent();

        public ExecutionEvent onBeginExecuting;
        public ExecutionEvent isExecuting;
        public ExecutionEvent onDoneExecuting;

        //Why don't I see these?
        protected void OnBeginExecuting()
        {
            if (onBeginExecuting != null)
            {
                onBeginExecuting();
            }
        }

        protected void IsExecuting()
        {
            if (isExecuting != null)
            {
                isExecuting();
            }
        }

        protected void OnDoneExecuting()
        {
            if (onDoneExecuting != null)
            {
                onDoneExecuting();
            }
        }


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