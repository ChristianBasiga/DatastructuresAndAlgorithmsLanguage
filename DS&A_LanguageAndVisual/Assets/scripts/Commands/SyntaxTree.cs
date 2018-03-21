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
            root.id = "root";
        }

        //Start is now set up
        public void start()
        {
            current = root;

            
            //Cause new program is starting to allocate memory for this program to run.
            variables = new Dictionary<string, Variable>();
            bodies = new Stack<SyntaxNode>();
            bodies.Push(current);

        }

        //This will be running it one go
        public void run()
        {
            while (bodies.Count > 0)
            {
                traverseRight();
            }
        }

        //This is for stepping through one at a time, hsa it's use on it's own but main reason right now
        //is for visual representation, bool for whether or not any more lines left
        public bool nextLine()
        {

            //why is it skipping first one
            if (bodies.Count > 0)
            {

                current.doneExecuting();

                traverseRight();
                //Will add this method later
                return true;
            }
          
            return false;
        }

        public void add(SyntaxNode node, List<int> bodies, int bodyDimension, bool forElse = false)
        {
            constructed = true;
            if (root == null)
            {
                node = root;
                return;
            }
            current = root;
            SyntaxNode prev = current;

            //bodies length is how many bodies deep we wre taking current, with body line being which body we're traversing to, for easier sakes could just say line count instead
            //since gotta traverse everything anyway, instead of checking if has a right node, though I could do that, I'll write it in and try both ways.
            //That's where I fucked up, only up to line dimensions not all of bodies,
            //cause not clearing anymore to make more efficient.
            foreach (int line in bodies)
            {
                //Then traverse left to that body line, then traverse right, to enter that body, then repeat process to get to correct node.
                //this will go to null point initially, but that's okay, honestly at this point might as well just traverse right
                //with parameter then left till null, lol.but may want to actually overwrite stuff.
                for (int i = 0; i < line; ++i)
                {
                    prev = current;

                    current = current.leftChild();

                }

                if (current != null)
                {
                    prev = current;
                    current = current.rightChild();
                }
            }


            
            //Below is just deciding if should go to left or right child, and checking if has an else
            bool toRight = node is BlockNode;

            SyntaxNode toAttach = prev;
            //I gotta rethink way I'm doing this part to make else works cause I hate it though it works
            if (prev is IfElseNode && forElse)
            {
                IfElseNode ifElse = (IfElseNode)prev;

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
            node.setParent(toAttach);

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
            UnityEngine.Debug.Log("traversing left of " + current.id);

            current = current.leftChild();

            if (current == null)
            {
                UnityEngine.Debug.Log("left was null");

                SyntaxNode currentBody = bodies.Peek();
                if (currentBody == null)
                {
                    return;
                }

                if (currentBody is IConditional)
                {
                    IConditional conditional = (IConditional)currentBody;


                    //Because I'm always traversing right, so it needs to check the loop again.
                    if (conditional.Type == ConditionalType.LOOP)
                        current = currentBody.getParent();
                    else
                    {
                        currentBody.doneExecuting();
                        //Hmm I don't want it to traverse right again, and can't just et to left child of parent
                        //cause no guarantee it's there, plus would mean skipping it, could set to parent, then recur to this,
                        current = currentBody.getParent();
                        bodies.Pop();
                        traverseLeft();

                    }
                }
                //If it's not a loop then just goes to left node of parent
                else
                {
                    if (currentBody != root)
                    {
                        current = currentBody.getParent().leftChild();
                    }
                }

                if (bodies.Count > 0)
                    bodies.Pop();
            }
            else if (current is IExecute)
            {
                UnityEngine.Debug.Log("Executing " + current.id);
                IExecute executable = (IExecute)current;
                executable.execute(this);

            }
        }
    }
}