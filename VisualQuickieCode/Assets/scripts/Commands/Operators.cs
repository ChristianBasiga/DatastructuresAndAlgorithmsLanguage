using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;
using DataStructureLanguage.Syntax.Util;


public class Operators {

    public delegate bool LogicalOperation(Variable a, Variable b);
    public delegate Variable ArithmeticOperation(Variable a, Variable b);
    public delegate void AssignmentOperation(Variable assignee, Variable value);


    public static readonly Dictionary<string, AssignmentOperation> assignmentOperations = new Dictionary<string, AssignmentOperation>()
    {

        //Need to overload these operators, that or just do operatiosn here but overloading looks cleaner
        //Should the check for existance happen here?

        {"=" ,  (Variable assignee, Variable value) => { assignee = value; } },
         //Will just do this for now, rest are extra shit.


    };
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
