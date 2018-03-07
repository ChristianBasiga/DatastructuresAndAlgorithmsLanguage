using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;

    //May update this toa bstract factory later
    public class SyntaxNodeFactory  {

    public static SyntaxNode produce(string type)
    {
        
        //Give default constructor for all of visual nodes.
        if (type == "while")
        {
            return new WhileLoopNode();
        }
        else if (type == "for")
        {
            return new ForLoopNode();
        }
        else if (type == "if")
        {
            return new IfNode();
        }
        else if (type == "ifelse")
        {
            return new IfElseNode();
        }

        return new SyntaxNode();
        //Ad in as neded
    }
	
}
