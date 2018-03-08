using System.Collections;
using System.Collections.Generic;


public interface IConditional
{

    bool didPass(DataStructureLanguage.Syntax.Util.SyntaxTree syntaxTree);
    string Type { get; }

}

