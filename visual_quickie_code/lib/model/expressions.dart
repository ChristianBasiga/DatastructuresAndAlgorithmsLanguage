
library expressions;

import 'environment.dart';
import 'statements.dart';


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

class FunctionExpression extends ExpressionNode{


  ExpressionNode returnValue;
  ExpressionNode arguments;

  //Easy to implement cause on user end if they change to have return value, then I simply wrap function statement around expression.
  FunctionStatement body;


  @override
  VariableNode exec(Environment env){

    //Do everything in body

    //Then the return statement.
    return returnValue.exec(env);
  }
}