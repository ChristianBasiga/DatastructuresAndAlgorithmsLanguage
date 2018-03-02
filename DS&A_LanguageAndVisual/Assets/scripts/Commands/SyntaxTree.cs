using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.Util
{
    //Note: I am not commenting any of this for a reason, it should make perfect sense.
    public class SyntaxTree
    {
        DataStructureLanguage.Syntax.SyntaxNode root;
        DataStructureLanguage.Syntax.SyntaxNode current;

        //To go back to from previous body, basically like a stackframe, except for any blocks
        Stack<DataStructureLanguage.Syntax.SyntaxNode> prevBodies;

        public SyntaxTree(DataStructureLanguage.Syntax.SyntaxNode root)
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
            
            if (newBlock is LogicalOperationNode)
            {
                LogicalOperationNode lop = (LogicalOperationNode)newBlock;

                if (!lop.didPass())
                {
                    if (lop is IfElseNode)
                    {
                        if (lop.Else == null)
                        {
                            traverseLeft();
                        }
                        else
                        {
                            prevBodies.Push(current);
                            current = lop.Else;
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

                current.modifyLeftChild(prev);
            }
        }
    }
}