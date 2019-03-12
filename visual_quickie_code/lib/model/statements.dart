library statements;

import 'dart:async';
import 'dart:collection';
import 'environment.dart';
import 'expressions.dart';

class StatementStatus{

    bool executing;
    bool executed;
    int id;
}
//Let me rethink this structure a little
//So only some nodes have a next, operations, return their results
//but all have an exec.
//Also need an output 
abstract class StatementNode{

  StatementNode _next;

  //Set by the processor.
  Environment env;

  StatementStatus status;
  //Stuff put in sink would be, if it's executing, if it failed, etc.
  //Subscriber of these streams
  StreamController<StatementStatus> execStream;

  StatementNode(int id){


    execStream = StreamController<StatementStatus>();
    status = StatementStatus()
      ..id = id
      ..executing = false;
  }

  StatementNode get next{
    onEndExecuting();
    return _next;
  }

  void setNext(StatementNode toSet){

    _next = toSet;
  }


  //I want these to be protected
  void onBeginExecuting(){

      status.executing = true;
      execStream.sink.add(status);

  }

  void onEndExecuting(){

      status.executing = false;
      execStream.sink.add(status);
  }
  //Actually, this maybe tied to a specific node, not passed in here.
  //cause when call function, not passing in this environment but their own.
  //Let myself get confused and ignore my design with the base impl, but returning future makes sense.
  //Cause only makes sense on operations
  //so both have an exec method, but only one of them returns a promise, other is void.
  void exec();
}

abstract class BlockStatement extends StatementNode{

  StatementNode body;

  //Continue block this block is in.
  StatementNode continueBlock;
  
  BlockStatement(int id) :super(id);

//After return, want to set _return to.
  @override
  StatementNode get next{

    onEndExecuting();
    if (status.executed){
      return continueBlock;
    }
    
    return _next;
  }

  @override
  void setNext(StatementNode toSet){

    continueBlock = toSet;
    super.setNext(toSet);
  }


  void setBody(StatementNode body){

    this.body = body;

    //Set tail of body to this.

    StatementNode current = this.body;

    //This is next of compilation phase, not execution.
    //not making this next of it's inner body but it's most outer next.
    //Maybe this process be done prior? When constructing the list from bloc since the function statement
    //will have been already been made, but putting here makes it clear.
    while (current._next != null){

      current = current._next;
    }

    //To make sure the reference to the loopback isn't lost for example in block statements
    //_next could be overwriten by body and envers set to continue block.
    current.setNext(this);
  }
}


//Void functions.
class FunctionStatement extends BlockStatement{

  //Hmm maybe parameters should be part of environment
  //The reason I say this is parameters should be part of the scope of inner blocks? Maybe their own environment nested here?
  Environment _parameters;

  FunctionStatement(int id, Environment parameters) :super(id){

    _parameters = parameters;
    
    //Setting environment of functions must wrap around parameters
    //parameters should have same as local, not be after global.
    //So in scope.
  }

  
  
  //Basically assigns what next means.
  void exec(){

    _next = body;
  }
}

//Honestly this exact same structure could be used for all, only difference is I reset it at next.
class ConditionalStatement extends BlockStatement{


  bool isLoop;
  BlockStatement elseNext;
  ExpressionNode conditionalExpression;
  ConditionalStatement(int id) :super(id){

    
    //Setting environment of functions must wrap around parameters
    //parameters should have same as local, not be after global.
    //So in scope.
  }

  //Could be else if.
  //Once again ideally, I set the loop prior to setting here
  //also would reduce the duplicate code of body and this.
  ///BIG NOTE HERE TO DO THAT WHEN START DOING BLOCS / CONTROLLERS.
  void setElse(BlockStatement elseStatement){

    elseNext = elseStatement;
    //Same process as setting body, just make this loop back here.

    StatementNode current = elseNext;
    
    //Not accessing getter becaues at outermost layer I want next not inner
    //using private member that I can access so that I don't set next of wrong statement.
    //Ideally use protected but Dart doesn't have that.
    while (current._next != null){

        current = current._next;
    }

    //Same reason as above, make it so loopback is this, review on paper later.
    current.setNext(this);
  }


  @override
  StatementNode get next{
    onEndExecuting();
    if (status.executed){

      if (isLoop){
        //doing within here, makes it so I don't gotta do ugly and expensive type in processor.
        exec();
        return _next;
      }
      else{

        return continueBlock;
      }
    }
    else{

      return _next;
    }


  }

  void exec(){

    onBeginExecuting();

    //Here as well, gotta make sure the wait.
    //Okay, I get it surface level, if function expression, but what if it's function expr + function expr
    VariableNode condition = conditionalExpression.exec(env);

    if (condition.data == "true"){

      _next = body;
    }
    else if (elseNext != null){

      //Then when this is returned by next, and its exec gets called, if it is else if
      //then repeats this process for that node, if it is just a block, then just goes through body.
      _next = elseNext;
    }
    else{
      _next = continueBlock;
    }
  }
}


class AssignmentStatement extends StatementNode{

  ExpressionNode rhs;
  String lhsIdentifier;
  AssignmentStatement(int id) :super(id);

  @override
  void exec(){


    //Now rhs, can be a function call expression.
     VariableNode result = rhs.exec(env);

     VariableNode lhs = env.findVar(lhsIdentifier);

     lhs.data = result.data;
    //Then do find var with identifier, then assign the result as new value.
  }
}



