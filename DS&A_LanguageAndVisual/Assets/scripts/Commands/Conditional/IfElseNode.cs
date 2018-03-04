using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;

    namespace DataStructureLanguage.Syntax.SyntaxNodes { 

    //I was being retarded lsat night, Logical OperationNodes is some IfElseNodes HAVE has-a relationship not is-a
    public class IfElseNode : IfNode {

        Operators.LogicalOperation condition;

        public SyntaxNode elseBody;
        //Problem with that is I actually restrict it to having to have two operands and an operator.
        //Which is retarded, because !d is a thing, though I could translate that to != false to though like actually.
        //Fuck it getting working,meant to make complete but just make shitty in different way? Same overloads same attributes yet no relation between them
        //Unless I make an If , then IfElse, I mean slack does it and it worked for me in iOS so why not.
        public IfElseNode(Variable first, Variable second, string operation) : base(first, second, operation)
        {
        }

        public SyntaxNode Else
        {
            get
            {
                return elseBody;
            }
            set
            {
                elseBody = value;
            }
        }

    }
}