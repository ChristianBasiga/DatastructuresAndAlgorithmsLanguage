library project;

import 'dart:collection';
import 'environment.dart';
import 'statements.dart';
import 'expressions.dart';

class Program{

  Environment global;

  //How should I store list of functions?
  //Function statements? But then what of function expressions? Well I guess that's also using identifier to get function statement
  //to assign to a expression.

  //Toggling between statement and expression
  //requires moving from one list to another
  //but that's just setting keyed val to null, then other to actual, so not big.
  HashMap<String, FunctionStatement> functionStatements;
  HashMap<String, FunctionExpression> functionExpressions;

  FunctionStatement main;

}

class Process{

  Program programProcessing;
  StatementNode current;


  //So for executing this is all it needs to do
  //But for doing function expressions, I need to send back data.
  //This exec is essentially exec of main function and project and returns value of main function
  //so returned value is expression in function expression, functions just need to be executed for that to happen.
  //and have their environments set to execute the return value correctly.
  //I actually don't have to do anything else here.
  void exec(){


    current = programProcessing.main;

    while (current.next != null){

        //Some ugly type checking, but can't think of another way for environment passing around atm.

        if (current is FunctionStatement){

            LocalEnvironment functionEnviron = LocalEnvironment()
              ..decorating = programProcessing.global;
            
            current.env = functionEnviron;
        }
        else if (current is BlockStatement){

          LocalEnvironment blockEnviron = LocalEnvironment()
            ..decorating = current.env;

          current.env = blockEnviron;
        }

        current.exec();

        current = current.next;
    }    
  }
}


//Can run multiple processes.
//but has one main process;
class Processor{

  static Process mainProcess;
}