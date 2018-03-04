using System.Collections;
using System.Collections.Generic;

namespace DataStructureLanguage.Syntax.SyntaxNodes {

    public delegate bool LogicalOperation(Variable<int> a, Variable<int> b);

    public static Dictionary<string, LogicalOperation> logicalOperations = new Dictionary<char, LogicalOperation>()
    {

        { "<" , (Variable<int> a, Variable<int> b) => { return a < b; } },
        { ">" , (Variable<int> a, Variable<int> b) => { return a > b; } },
        { "==" , (Variable<int> a, Variable<int> b) => { return a == b; } },
        { "!=" , (Variable<int> a, Variable<int> b) => { return a != b; } },
        { ">=" , (Variable<int> a, Variable<int> b) => { return a >= b; } },
        { "<=" , (Variable<int> a, Variable<int> b) => { return a <= b; } },

    };


    public abstract class LogicalOperationNode : BinaryOperationNode, ISyntaxNode{

        public new bool operate()
        {
            return logicalOperations[theOperator](operand1,operand2);
        }

    }
}