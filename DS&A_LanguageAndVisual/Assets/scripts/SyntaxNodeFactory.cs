using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;

//May update this to abstract factory later, but at this point, no real point to it.
public class SyntaxNodeFactory
{

    public static SyntaxNode produce(string type)
    {
        if (type != null)
             type = type.ToLower();

        //Give default constructor for all of visual nodes.
        if (type == "while")
        {
            return new WhileLoopNode();
        }
        else if (type == "if")
        {
            UnityEngine.Debug.Log("Type constructing is " + type);


            return new IfNode();
        }
        else if (type == "ifelse")
        {
            return new IfElseNode();
        }
        else if (type == "assignment")
        {
            return new AssignmentNode();
        }

        return new BinaryOperationNode();
    }

}
