using System.Collections;
using System.Collections.Generic;
using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    //Lol this is actually retarded, at this point this class is not needed just check if was While as last body to see in terms of text
    //then that means check it again, cause it actually has no other fucking purpose lol. It did when I gave it a body in iOS version but there were
    //alot of things wrong with that approach, even though it did work. It's only purpose at this point is to check it's type and that's it.
    //and that could be replaced with fucking string ids
    public class WhileLoopNode : IfNode
    {

        public WhileLoopNode()
        {
            type = ConditionalType.LOOP;

        }
  


    }
}