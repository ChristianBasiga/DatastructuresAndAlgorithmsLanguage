using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;


    //Compiler for the visual nodes
    public class Compiler : MonoBehaviour {


    VisualNode root;
    DataStructureLanguage.Syntax.Util.SyntaxTree compiled;

    //This will be if for error checking or if just for running
    //may do both at same time but we'll see.
    enum ScanPurpose
    {

    }

    //Scans the code base
    public void scan()
    {
        VisualNode current = root;
        Stack<VisualNode> frames = new Stack<VisualNode>();
        frames.Push(current);

        while (frames.Count > 0)
        {
            VisualNode next = current.next;

            if (next is BlockVisual)
            {
                frames.Push(next);
                current = next;
                //current = next.next; This will be checked in next iteration so really just make it next no matter what, unless null
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

        }

    }

    
    public SyntaxNode constructSyntaxNode(VisualNode e)
    {

        SyntaxNode node = SyntaxNodeFactory.produce(e.ID);


        //TODo: Do make an executing node, that just execute for assignments or just assignmentnode, with it's variants. Shouldn't be too hard just dictionary for assignment and structured same as binaryOperations/
        if (node is BlockNode)
        {
            if (node is IfNode)
            {
                //It should still retain while if is while
                IfNode conditionalStatement = (IfNode)node;

                //Set it's attributes
            }
            else if (node is ForLoopNode)
            {
                ForLoopNode flNode = (ForLoopNode)node;

                //Set it's attributes
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
