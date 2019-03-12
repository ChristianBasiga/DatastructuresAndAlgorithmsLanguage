
library expressions;

import 'environment.dart';
import 'statements.dart';
import 'project.dart';


abstract class ExpressionNode{

  VariableNode exec(Environment env);
}

class BinaryExpression extends ExpressionNode{

    ExpressionNode lhs;
    ExpressionNode rhs;
    String operation;


    
    @override
    VariableNode exec(Environment env) {


        //What if they are function call expressions?
        VariableNode lhsResult =  lhs.exec(env);

        VariableNode rhsResult = rhs.exec(env);

        //Then access variable factory, passing in lhs result, rhs result and operator.
        //Separating so can be done for globals as well.

        VariableNode result;

        return result;
    }
}


//This is the unique case.


//Really need to document this part specifically, cause raw.
class FunctionExpression extends ExpressionNode{


  ExpressionNode returnValue;
  ExpressionNode arguments;

  //Easy to implement cause on user end if they change to have return value, then I simply wrap function statement around expression.
  //So this needs to be ran by another processor, wild.
  FunctionStatement body;


  @override
  VariableNode exec(Environment env){

    //Do everything in body


    //Now, how do I access the main processor's functions
    //unless static, but it's tied to specific program
    //unless make statements know what program they're being run on.

    Program program = Program()
      ..global = env
      ..main = body
      //Dirty static, but whatever for now, once get it working, this is something I could think up better design for later without
      //hopefully without changing too much.
      ..functionExpressions = Processor.mainProcess.programProcessing.functionExpressions
      ..functionStatements = Processor.mainProcess.programProcessing.functionStatements;

    //Run and set environment of local function and whatever else.
    Process()
      ..programProcessing = program
      ..exec();

    //Then the return statement.
    return returnValue.exec(env);
  }
}