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
    return _next;
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
  
  BlockStatement(int id) :super(id);

  void setBody(StatementNode body){

    this.body = body;

    //Set tail of body to this.

    StatementNode current = this.body;

    //This is next of compilation phase, not execution.
    //not making this next of it's inner body but it's most outer next.
    //Maybe this process be done prior? When constructing the list from bloc since the function statement
    //will have been already been made, but putting here makes it clear.
    while (current.next != null){

      current = current._next;
    }

    current._next = this;
  }
}


//Void functions.
class FunctionStatement extends BlockStatement{

  //Hmm maybe parameters should be part of environment
  //The reason I say this is parameters should be part of the scope of inner blocks? Maybe their own environment nested here?
  Environment _parameters;
  StatementNode _returnTo;
  FunctionStatement(int id, Environment parameters) :super(id){

    _parameters = parameters;
    
    //Setting environment of functions must wrap around parameters
    //parameters should have same as local, not be after global.
    //So in scope.
  }

  void exec(){

    //Exec of function statement means virtually nothing.
    _returnTo = _next;
    _next = body;
  }
}



