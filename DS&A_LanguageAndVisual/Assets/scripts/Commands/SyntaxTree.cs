using System.Collections;
using System;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;

namespace DataStructureLanguage.Syntax.Util
{
    //Note: I am not commenting any of this for a reason, it should make perfect sense.
    public class SyntaxTree
    {
        SyntaxNode root;
        SyntaxNode current;
        bool constructed = false;
       
        //To go back to from current body, basically a stackframe, everytime enters new block we push that new blck into this body and top of it is block we are currently in
        Stack<SyntaxNode> bodies;

        //Variables for SyntaxTree of this program, see makes sense to be here and can be public cause fill be emptied everytime re-run program;
        public Dictionary<string, Variable> variables;



        public bool Compiled
        {
            get
            {
                return constructed;
            }
        }
        public SyntaxTree(SyntaxNode root)
        {
            this.root = root;
        }


        public SyntaxTree()
        {
            root = new BlockNode();
        }

        public void start()
        {
            current = root;

            if (current.leftChild() == null)
            {
                UnityEngine.Debug.Log("what happened");
                return;
            }
            //Cause new program is starting to allocate memory for this program to run.
            variables = new Dictionary<string, Variable>();
            bodies = new Stack<SyntaxNode>();
            bodies.Push(current);


            while (bodies.Count > 0)
            {
                traverseRight();
            }
        }

        public void add(SyntaxNode node, List<int> bodies, bool forElse = false)
        {
            constructed = true;
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
                for (int i = 1; i < bodyLine; ++i)
                {

                    UnityEngine.Debug.Log("Body line is " + bodyLine);
                    if (current.leftChild() == null)
                    {
                        UnityEngine.Debug.Log("no left child");
                    }
                    current = current.leftChild();
                    UnityEngine.Debug.Log("state of tree is " + current);
                }
                if (current.rightChild() != null)
                    current = current.rightChild();
            }


            //Below is just deciding if should go to left or right child, and checking if has an else
            bool toRight = node is BlockNode;
            UnityEngine.Debug.Log(current == null);
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
                UnityEngine.Debug.Log("hello");

                if (toRight)
                {
                    toAttach.setRightChild((BlockNode)node);
                }
                else
                {
                    UnityEngine.Debug.Log("adding to left child of root");
                    UnityEngine.Debug.Log(toAttach == root);
                    toAttach.setLeftChild(node);
                }
            }

        }

        //This is all body transferring
        private void traverseRight()
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
        private void traverseLeft()
        {
            UnityEngine.Debug.Log("traversing left");
            UnityEngine.Debug.Log(current.leftChild() == null);
            current = current.leftChild();

            if (current == null)
            {
                UnityEngine.Debug.Log("left was null");

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
                    if (prev != root)
                    {
                        current = prev.getParent().leftChild();
                    }
                }

                bodies.Pop();
            }
            else if (current is IExecute)
            {
                UnityEngine.Debug.Log("hello");
                IExecute executable = (IExecute)current;
                executable.execute(this);

            }
        }
    }
}