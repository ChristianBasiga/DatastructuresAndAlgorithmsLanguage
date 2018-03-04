using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.SyntaxNodes;
using DataStructureLanguage.Syntax.Util;


public class Operators {

    public static readonly Dictionary<string, LogicalOperation> logicalOperations = new Dictionary<string, LogicalOperation>()
    {

        { "<" , (Variable a, Variable b) => { return a < b; } },
        { ">" , (Variable a, Variable b) => { return a > b; } },
        { "==" , (Variable a, Variable b) => { return a == b; } },
        { "!=" , (Variable a, Variable b) => { return a != b; } },
        { ">=" , (Variable a, Variable b) => { return a >= b; } },
        { "<=" , (Variable a, Variable b) => { return a <= b; } },
    };



}
