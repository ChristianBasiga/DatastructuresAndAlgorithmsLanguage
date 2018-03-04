using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;
namespace DataStructureLanguage.Syntax.Util
{
    //Note: I am not commenting any of this for a reason, it should make perfect sense.
    public class SyntaxTree
    {
        SyntaxNode root;
        SyntaxNode current;

        //To go back to from previous body, basically like a stackframe, except for any blocks
        Stack<SyntaxNode> prevBodies;

        public SyntaxTree(SyntaxNode root)
        {
            this.root = root;
            current = root;
        }

        public void traverseRight()
        {
            if (current.rightChild() == null)
            {
                traverseLeft();
                return;
            }

            BlockNode newBlock = current.rightChild();
            
            if (newBlock is IConditional)
            {
                IConditional lop = (IConditional)newBlock;

                if (!lop.didPass())
                {
                    if (lop is IfElseNode)
                    {
                        IfElseNode ifElse = (IfElseNode)lop;
                        if (ifElse.Else == null)
                        {
                            traverseLeft();
                        }
                        else
                        {
                            prevBodies.Push(current);
                            current = ifElse.Else;
                        }
                    }
                    else 
                        traverseLeft();
                }
                else
                {
                    prevBodies.Push(current);
                    current = newBlock;
                }
            }
       
        }

        public void traverseLeft()
        {
            current = current.leftChild();

            if (current.leftChild() == null)
            {
                SyntaxNode prev = prevBodies.Peek();
                prevBodies.Pop();

                current.setLeftChild(prev);
            }
        }
    }
}