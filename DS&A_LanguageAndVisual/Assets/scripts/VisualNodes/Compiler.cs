using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;


    //Compiler for the visual nodes
    public class Compiler {


    VisualNode root;
    DataStructureLanguage.Syntax.Util.SyntaxTree compiled;

    //This will be if for error checking or if just for running
    //may do both at same time but we'll see.
    enum ScanPurpose
    {

    }



    public Compiler(VisualNode root)
    {
        this.root = root;
        compiled.add(root, null);

    }

    //Scans the code base
    public void scan()
    {
        VisualNode current = root;
        Stack<VisualNode> frames = new Stack<VisualNode>();
        //frames.Push(current);

        //I think the next stuff here is fine
        do 
        {
            VisualNode next = current.next;

            if (next is BlockVisual)
            {
                frames.Push(next);
                current = next;
            }
            else if (next == null)
            {
                current = frames.Peek();
                frames.Pop();
            }
            else
            {
                current = next;
            }
            SyntaxNode syntaxNode = constructSyntaxNode(current);
            if (syntaxNode != null)
            {
                //Gotta keep track of head per body

                if ()
                {
                    compiled.add(current, current.lineNumbers, true);
                }
                else
                    compiled.add(current, current.lineNumbers);

            }
        }
        while (frames.Count > 0);

    }

    public void execute()
    {
        //Just test this out first, if runs without errors then work on syncing
        compiled.start();
    }

    
    public SyntaxNode constructSyntaxNode(VisualNode e)
    {

        SyntaxNode node = SyntaxNodeFactory.produce(e.ID);


        //TODo: Do make an executing node, that just execute for assignments or just assignmentnode, with it's variants. Shouldn't be too hard just dictionary for assignment and structured same as binaryOperations/
        //This will take priority, need to give them the exec method
        if (node is BlockNode)
        {
            if (node is IfNode)
            {
                //It should still retain while if is while
                IfNode conditionalStatement = (IfNode)node;

                //Set it's attributes with fields
            }
            else if (node is ForLoopNode)
            {
                ForLoopNode flNode = (ForLoopNode)node;

                //Set it's attributes with fields
            }

        }

        return node;

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
