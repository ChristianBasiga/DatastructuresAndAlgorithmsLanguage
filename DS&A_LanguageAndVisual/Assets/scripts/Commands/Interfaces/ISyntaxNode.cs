using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public interface ISyntaxNode
    {
        SyntaxNode Parent
        {

            get;set;
        }

        void exec();


    }
}