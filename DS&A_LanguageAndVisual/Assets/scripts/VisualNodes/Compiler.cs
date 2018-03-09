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
        //Purely to know when to stop.
        Stack<VisualNode> frames = new Stack<VisualNode>();
        //frames.Push(current);

        //I think the next stuff here is fine
        do 
        {
            //Now regadless if BlockVisual or not will still work as expected
            VisualNode next = current.Next;

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

                BlockVisual block = getOwningBody(syntaxNode);

                if (block.id == "else")
                {
                    compiled.add(syntaxNode, current.lineNumbers, true);
                }
                else
                    compiled.add(syntaxNode, current.lineNumbers);
                    
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
                //Move these three to a function, since duplicate code, but that's polish.
                conditionalStatement.FirstOperand = condition.firstOperand.text;
                conditionalStatement.SecondOperand = condition.secondOperand.text;
                conditionalStatement.SetOperator(condition.operators.options[condition.operators.value].text);

                ifBlock.SetCondition = conditionalStatement;

            }
            //Do this later, get working for minimum stuff
            else if (node is ForLoopNode)
            {
                ForLoopNode flNode = (ForLoopNode)node;

                //Set it's attributes with fields
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
        node.SetOperator(binaryOperationVisual.operators.options[binaryOperationVisual.operators.value].text);
    }

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

#endregion
}
