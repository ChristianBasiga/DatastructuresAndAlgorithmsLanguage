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
        }


        public SyntaxTree()
        {
        }

        public void start()
        {
            current = root;
        }

        //I hate the forElse parameter but fuck it man to make it work for now.
        public void add(SyntaxNode node, int bodiesDeep, bool forElse = false)
        {
            if (root == null)
            {
                node = root;
                return;
            }
            current = root;
            int bodiesTraversed = 0;
            while (bodiesTraversed < bodiesDeep || current.leftChild() != null)
            {
                if (current.rightChild() != null && bodiesTraversed < bodiesDeep)
                {
                    current = current.rightChild();
                    bodiesTraversed += 1;
                }
                else
                {
                    current = current.leftChild();
                }
            }

            bool toRight = node is BlockNode;

            SyntaxNode toAttach = current;
            if (current is IfElseNode && forElse)
            {             
                    IfElseNode ifElse = (IfElseNode)current;
                    toAttach = ifElse.elseBody;
            }
            else
            {
                if (toRight)
                {
                    toAttach.setRightChild((BlockNode)node);
                }
                else
                {
                    toAttach.setLeftChild(node);
                }
            }

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
                if (prev == null)
                {
                    return;
                }
                prevBodies.Pop();

                current.setLeftChild(prev);
            }


        }
    }
}