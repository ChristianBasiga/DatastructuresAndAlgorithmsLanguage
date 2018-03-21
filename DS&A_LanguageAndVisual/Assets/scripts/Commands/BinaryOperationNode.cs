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

        //Might actually make this apart of SyntaxNode, cause bodies execute is really just calling execute on inner blocks like
        //conditions
        public virtual void execute(Util.SyntaxTree syntaxTree)
        {
            //Need to make it so this is updated every frame, so need to be yielded per frame, hmm
            //Will just do like how I did in iOS, I have th eone go start, and will have the one step at a time methods as well
            //then coroutine will be within compiler instead.!!!!!!!! DO THIS, but first make sure it works in one go.
            UnityEngine.Debug.Log("beginning execution of " + this.id);
            OnBeginExecuting();
       //     OnDoneExecuting();

        }

        
    }
}