 [Model](#Model-Code)

# Model Code

**Project**

    class Project{

    //stores global variables as a dictionary or own implemented BST.
    //stores function addresses.
    //has root Node, pointer to main.
    //has Program Counter
    }
**Node**

    class Node {

    //Has onExec callbacks, probably through streams to give feedback to View.
    //Has exec method with base implementation of calling the callbacks.
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
    //exec signals error if parameters not set, execution stops.
    //name
    //getId, id is name and parameter names, essentially like overloading
    }

**OperationNode**

    class OperationNode : Node{

    //Right hand side is Operation Node because it can be expression.
    //left hand side is a node.
    }
