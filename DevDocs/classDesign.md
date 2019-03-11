 [Model](#Model-Code)

 [Controller](#Controller-Code)

 [View](#View)

 --------------------------------------
# Model Code
This code can be transferred from platform to platform.
So using bloc here would be good

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

Adding to stream transform parsing from visual node to executable node,
then attaching callback to visual node on executable.

There will be a class that holds all data.

There will be a bloc for every screen, that accesses subsets of model's data that only they need.

Views will go to bloc, bloc will transform for use in data, and transform back for use in view

# View

https://pub.dartlang.org/packages/flutter_reorderable_list
Nodes will be displayed on reordable list per block.
Each block will open to it's own screen with it's own list of nodes.
ie:
- operation
- whileLoop condition
- operation operation
- operation operation
- operation

**Project Form**

*Fields*

- name
- global variables

**Function Form**

*Fields*

- name
- constant / static variables


**Form for each respective Node**

*ConditionalNodes*
- Condition

*OperationNodes*
- operands
- operator

**Project Screen**

- Has list of functions
- Has list of global variables

**Function Screen**

- Can update fields on function form.
- Can add nodes like all block screens.

**Conditional Block Screen**

- Can update condition
- Can add nodes.
