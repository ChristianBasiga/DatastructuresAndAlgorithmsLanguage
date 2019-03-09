

[Purpose](#purpose)

[Core Features](#core-features)

[Stretch Goals](#stretch-goals)

[User Stories](#user-stories)

[Architecture](#architecture)

[Front End Stack](#front-end-stack)

[Back End Stack](#back-end-stack)

# Purpose
-----------------
Provide a visual interface for creating and seeing the execution of
short programs for algorithm testing and teaching. The coding is drag
and drop and the execution displays the flow of the program and what is
currently happening.

# Core Features
-----------------

Running their written Programs.

Drag and Drop Mechanic.

Storing Variables

Creation of all Visual Nodes

Conditional Nodes

Functions

Swipe between functions.

Visual Indication of execution of program outside of just output.

During

After

# Stretch Goals
-----------------

Saving Created Programs

-   The program itself

-   The execution flow output. (Because the output is main purpose of
    it.)

Ability to Pause the execution.

Animations

-   Creating Nodes

-   Executing Program

# User Actions
-----------------

*Create Node*
1. Open menu with options of Nodes can create.

2. Select Node

3. Open form of respective Node

4. Creates the Visual representation of node, appends to node list of current block.


*Move Node*

1. Click and drag

2. Can only drag across list of nodes in current block.

3. They are placed in list view.

*Create Function*

1. Opens form to set parameters and function name.

2. Then open function window to add nodes to.

3. Added to list of functions in current project.

*Create Project*
1. Open up form to give project name.

2. Can set global variables.

3. Main function created.

4. Opens up to project window.

*Run Code*
1. Open up function window of main.

2. Iterate through list of nodes, running parse on each one.

3. Once parsing is done, begin executing the main function.

4. As it runs, callbacks are executed to output to console window, and generate
a flattened sequence of nodes executed.

*Operation Done*
1. This could be function call, assignment operator, arithmetic, etc.

2. Operands / parameters are parsed using regex to distinguish between identifiers
and constants / literals.

3. For identifiers, recursively looks for it up the tree to outer blocks to find first match.

4. Parse Operator, then execute accordingly, returning promise of result if any.

# Architecture
-----------------

### Front End Stack

Flutter

Dart

Pub

### Back End Stack

.Net Core

C#

dotnet
