 [Model](#Model-Code)

 [Controller](#Controller-Code)

 --------------------------------------
# Model Code

**Project**

    class Project{

    /*stores global variables as a dictionary or own implemented BST.*/

    //stores function addresses.

    //has root Node, pointer to main.

    //has Program Counter
    }
**Node**

    class Node {

    /*Has onExec callbacks, probably through streams to give feedback to View.*/

    /*Has exec method with base implementation of calling the callbacks*/

    //exec returns a promise.

    /*Has passed in variablesNode, each block in it is decorated to contain a new stackframe of local variables, simulates the same concept of actual block scope variables.*/

    //Has a next Node

    }

**BlockNode**

    class BlockNode : Node{

    //local variables

    //Node body.

    //overrides exec method to execute everything in body, then calls super.

    }

**FunctionNode**

    class Function : BlockNode{

    //has parameters.

    /*exec signals error if parameters not set, execution stops.*/

    //name

    /*getId returns id which is name concat parameter names, essentially like overloading*/

    }

**OperationNode**

    class OperationNode : Node{

    /*All operands are OperationNodes, because can be expressions.*/

    //Will have a constructor that takes in single value

    /*for converting from expression to const / literal or
    variable in operation*/

    //Assignment Operation may be own thing since has to be

    //variable on lhs.

    }

**AssignmentNode**

  class AssignmentNode : Node{

    //lhs is variable.

    //Will not consider returned variables from expressions.

    //rhs is operationNode

    //Then operation node parses if just variable or const.

    /*exec creates or updates variable reference fund through findVariable*/
  }

# Controller code
