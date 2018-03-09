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

        //To go back to from current body, basically a stackframe, everytime enters new block we push that new blck into this body and top of it is block we are currently in
        Stack<SyntaxNode> bodies;

        //Variables for SyntaxTree of this program, see makes sense to be here and can be public cause fill be emptied everytime re-run program;
        public Dictionary<string, Variable> variables;




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
            //Cause new program is starting to allocate memory for this program to run.
            variables = new Dictionary<string, Variable>();
            bodies.Push(current);
        }

        //I hate the forElse parameter but fuck it man to make it work for now.
        public void add(SyntaxNode node, List<int> bodies, bool forElse = false)
        {
            if (root == null)
            {
                node = root;
                return;
            }
            current = root;
            //bodies length is how many bodies deep we wre taking current, with body line being which body we're traversing to, for easier sakes could just say line count instead
            //since gotta traverse everything anyway, instead of checking if has a right node, though I could do that, I'll write it in and try both ways.
            foreach (int bodyLine in bodies)
            {
                //Then traverse left to that body line, then traverse right, to enter that body, then repeat process to get to correct node.
                for (int i = 0; i < bodyLine; ++i)
                {
                    current = current.leftChild();
                }

                current = current.rightChild();
            }


            //Below is just deciding if should go to left or right child, and checking if has an else
            bool toRight = node is BlockNode;

            SyntaxNode toAttach = current;
            //I gotta rethink way I'm doing this part to make else works cause I hate it though it works
            if (current is IfElseNode && forElse)
            {
                IfElseNode ifElse = (IfElseNode)current;

                if (ifElse.elseBody == null)
                    ifElse.elseBody = node;
                else
                {
                    toAttach = ifElse.elseBody;
                }

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

        //This is all body transferring
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

                if (!lop.didPass(this))
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
                            current = ifElse.Else;
                            bodies.Push(current);

                        }
                    }
                    else 
                        traverseLeft();
                }
                else
                {
                    current = newBlock;
                    bodies.Push(current);
                }
            }
       
        }

        //This is for executing other statements
        public void traverseLeft()
        {
            current = current.leftChild();

            if (current == null)
            {
                SyntaxNode prev = bodies.Peek();
                if (prev == null)
                {
                    return;
                }

                if (prev is IConditional)
                {
                    IConditional conditional = (IConditional)prev;

                    //Right, it was for this reason, I mean I could just check if it's a loop tbh
                    //problem with that is it's not easily extendable to more loops, cause I'll have to change this code.
                    if (conditional.Type == ConditionalType.LOOP)
                        current = prev.getParent();
                   
                }
                //If it's not a loop then just goes to left node of parent
                else
                {
                    current = prev.getParent().leftChild();
                }

                bodies.Pop();
            }
            else if (current is IExecute)
            {
                IExecute executable = (IExecute)current;
                executable.execute(this);

            }
        }
    }
}