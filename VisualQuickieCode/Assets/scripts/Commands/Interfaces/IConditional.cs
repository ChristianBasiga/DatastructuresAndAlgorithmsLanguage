using System.Collections;
using System.Collections.Generic;


public enum ConditionalType
{
    LOOP,
    IF,
    IFELSE
}
public interface IConditional
{

    bool didPass(DataStructureLanguage.Syntax.Util.SyntaxTree syntaxTree);
    ConditionalType Type { get; }
}

