using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;

//May update this to abstract factory later, but at this point, no real point to it.
public class SyntaxNodeFactory
{

    public static SyntaxNode produce(string type)
    {

        //Give default constructor for all of visual nodes.
        if (type == "while")
        {
            return new WhileLoopNode();
        }
        else if (type == "if")
        {
            return new IfNode();
        }
        else if (type == "ifelse")
        {
            return new IfElseNode();
        }

        return new IfElseNode();
    }

}
