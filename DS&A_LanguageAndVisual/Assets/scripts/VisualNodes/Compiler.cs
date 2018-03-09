using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructureLanguage.Syntax.SyntaxNodes;


    //Compiler for the visual nodes
    public class Compiler {


    BlockVisual root;
    DataStructureLanguage.Syntax.Util.SyntaxTree compiled;

    //This will be if for error checking or if just for running
    //may do both at same time but we'll see.
    enum ScanPurpose
    {

    }



    //Need to test this Compiler, but due to time constraints I'll test in one go.
    //Syntax tree for sure works, visualNode structure works, the parsing phase is the one to test, but should also theoritaclly work.
    public Compiler(BlockVisual root)
    {
        this.root = root;
        //Actually root is always set to means tart of program, they don't start that, it's just for me.

    }

    //Scans the code base
    public void scan()
    {
        VisualNode current = root;

        //To keep track of bodies.
        Stack<BlockVisual> frames = new Stack<BlockVisual>();
        List<int> lineNumbers = new List<int>();
        lineNumbers.Add(0);
        //Representing how many levels deep lineNumber is in, basically the index.
        int lineDimension = 0;

        do 
        {
            //Now regadless if BlockVisual or not will still work as expected
            VisualNode next = current.Next;

            if (next is BlockVisual)
            {
                frames.Push((BlockVisual)next);
                current = next;
            }
            //Because with how set up next in BlockVisual, when I set it to current it's current's next is now going to be null, then it'll go to actual
            //next in outer body.
            else if (next == null)
            {
                current = frames.Peek();

                //Reset that spot for the next time enter new body.
                lineNumbers[lineDimension] = 0;

                frames.Pop();
            }
            else
            {
                lineNumbers[lineDimension]++;
                current = next;
            }
            SyntaxNode syntaxNode = constructSyntaxNode(current);
            if (syntaxNode != null)
            {
                //What happens when you take breaks in between dev. I don't need to backtrace, the last added BlockVisual is the body of this current node.
                //BlockVisual block = getOwningBody(syntaxNode);
                BlockVisual block = frames.Peek();

                if (block.ID == "else")
                {
                    compiled.add(syntaxNode, lineNumbers, true);
                }
                else
                    compiled.add(syntaxNode, lineNumbers);
                    
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

        if (node is BlockNode)
        {
            if (node is IfNode)
            {
                //It should still retain while if is while
                IfNode ifBlock = (IfNode)node;
                BinaryOperationNode conditionalStatement = new BinaryOperationNode();

                //Set it's attributes with fields in the operationVisual
                BlockVisual block = (BlockVisual)e;
                BinaryOperationVisual condition = (BinaryOperationVisual)block.Head;
                
                if (condition == null)
                {
                    //Throw an exception
                }

                convertBinaryOperation((BinaryOperationNode)conditionalStatement, (BinaryOperationVisual)e);
                ifBlock.SetCondition(conditionalStatement);
            }

        }
        else if (e is BinaryOperationVisual)
        {
            if (node is BinaryOperationNode)
            {
                convertBinaryOperation((BinaryOperationNode)node, (BinaryOperationVisual)e);
            }
        }

        //It should hold all it's changes.
        return node;

    }


#region Utility Methods
    private void convertBinaryOperation(BinaryOperationNode node, BinaryOperationVisual binaryOperationVisual)
    {
        node.FirstOperand = binaryOperationVisual.firstOperand.text;
        node.SecondOperand = binaryOperationVisual.secondOperand.text;
        node.Operation = binaryOperationVisual.operators.options[binaryOperationVisual.operators.value].text;
    }
    /* No longer needed, atleast for it's initial purpose for existing
    private BlockVisual getOwningBody(VisualNode visualNode)
    {
        //Trace back visual node to first BlockBody it sees, because that will be body it belongs to.
        VisualNode current = visualNode.Prev;

        while (!(current is BlockVisual))
        {
            current = current.Prev;
        }

        return (BlockVisual)current;
    }
    */
#endregion
}
