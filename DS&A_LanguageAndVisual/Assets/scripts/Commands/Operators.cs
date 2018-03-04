using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;
using DataStructureLanguage.Syntax.Util;


public class Operators {

    public delegate bool LogicalOperation(Variable a, Variable b);
    public delegate Variable ArithmeticOperation(Variable a, Variable b);

    public static readonly Dictionary<string, LogicalOperation> logicalOperations = new Dictionary<string, LogicalOperation>()
    {

        { "<" , (Variable a, Variable b) => { return a < b; } },
        { ">" , (Variable a, Variable b) => { return a > b; } },
        { "==" , (Variable a, Variable b) => { return a == b; } },
        { "!=" , (Variable a, Variable b) => { return a != b; } },
        { ">=" , (Variable a, Variable b) => { return a >= b; } },
        { "<=" , (Variable a, Variable b) => { return a <= b; } },
    };

    public static readonly Dictionary<string, ArithmeticOperation> arithmeticOperations = new Dictionary<string, ArithmeticOperation>()
    {

        { "+" , (Variable a, Variable b) => { return a + b; } },
        { "-" , (Variable a, Variable b) => { return a - b; } },
        { "/" , (Variable a, Variable b) => { return a / b; } },
        { "*" , (Variable a, Variable b) => { return a * b; } },
        { "%" , (Variable a, Variable b) => { return a % b; } },
    };
}
