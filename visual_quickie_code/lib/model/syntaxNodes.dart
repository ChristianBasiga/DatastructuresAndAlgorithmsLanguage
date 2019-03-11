import 'dart:async';
import 'dart:collection';
import 'environment.dart';

class SyntaxNodeStatus{

    bool executing;
    int id;

}
//Also need an output 
abstract class SyntaxNode{

  SyntaxNode next;
  Environment env;

  SyntaxNodeStatus status;
  //Stuff put in sink would be, if it's executing, if it failed, etc.
  //Subscriber of these streams
  StreamController<SyntaxNodeStatus> execStream;

  SyntaxNode(int id){


    execStream = StreamController<SyntaxNodeStatus>();
    status = SyntaxNodeStatus()
      ..id = id
      ..executing = false;
  }


  //I want these to be protected
  void onBeginExecuting(){

      status.executing = true;
      execStream.sink.add(status);

  }

  void _onEndExecuting(){

      status.executing = false;
      execStream.sink.add(status);
  }
  //Actually, this maybe tied to a specific node, not passed in here.
  //cause when call function, not passing in this environment but their own.
  void exec(){

      if (next == null){

        //What is returned will be overridden and used
        //Maybe returning future not make too much sense here, callbacks make more sense
        //
        return;
      }

      _onEndExecuting();
  }  
}

abstract class BlockNode extends SyntaxNode{

  SyntaxNode body;

  BlockNode(int id) :super(id);

  @override
  void exec(){

      body.exec();
      super.exec();
  } 
}