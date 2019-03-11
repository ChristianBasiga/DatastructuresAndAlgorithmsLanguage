import 'dart:collection';



//Simply to return by reference
class VariableNode{

  String data;
}


class Environment{

 //For simplicity and prototyping will make it map to strings, that I'll then parse to appropriate type.
 //I actually want a reference to this though.
 //So building out a BST might be better like original plan.
 //for now doing pseudo code but since I want ref of variable will do that.
 //Actually map is prob fine, Dart doesn't make reinventing the wheel like this very easy.
   HashMap<String, VariableNode> variables;

   Environment(){

    variables = HashMap<String, VariableNode>();
   }

   VariableNode findVar(String identifier){

      VariableNode var = (variables.containsKey(identifier))? variables[identifier] : null;

      return var;  
   }

}


//Each local environment would be function local variables, local to body of while loop, etc.
class LocalEnvironment extends Environment {


  Environment decorating;

  VariableNode findVar(String identifier){

    VariableNode var = super.findVar(identifier);
    //Will recursively go up tree, if didn't find in variables.

    //See if identifier in this instance, return if is.

    //Otherwise go up tree, ideally root is base Environment, but incase it's local and decorating is null.
    if (var == null && decorating != null){
      var = decorating.findVar(identifier);
    }

    return var;
  }
}


