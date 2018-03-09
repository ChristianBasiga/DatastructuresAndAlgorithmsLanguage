namespace DataStructureLanguage.Syntax.SyntaxNodes
{
    public class BinaryOperationNode : SyntaxNode
    {
        protected string firstOperand;
        protected string secondOperand;
        protected string operation;

        public string FirstOperand { get { return firstOperand; } set { firstOperand = value; } }
        public string SecondOperand { get { return secondOperand; } set { secondOperand = value; } }
        public string Operation { get { return operation; } set { operation = value; } }
    }
}