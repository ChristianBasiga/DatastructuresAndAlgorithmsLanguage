using DataStructureLanguage.Syntax.Util;

namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class BinaryOperationNode : SyntaxNode, IExecute
    {
        protected string firstOperand;
        protected string secondOperand;
        protected string operation;

        public string FirstOperand { get { return firstOperand; } set { firstOperand = value; } }
        public string SecondOperand { get { return secondOperand; } set { secondOperand = value; } }
        public string Operation { get { return operation; } set { operation = value; } }

        public void execute(Util.SyntaxTree syntaxTree)
        {
            //Need to make it so this is updated every frame, so need to be yielded per frame, hmm
            //Will just do like how I did in iOS, I have th eone go start, and will have the one step at a time methods as well
            //then coroutine will be within compiler instead.!!!!!!!! DO THIS, but first make sure it works in one go.
            OnBeginExecuting();
       //     OnDoneExecuting();

        }
    }
}