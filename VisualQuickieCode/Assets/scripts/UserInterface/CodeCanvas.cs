using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be where all the VisualNodes will be placed, this just has root, and How NodeMenu instantiates stuff will take care of attaching it to next of root, then I just pas root to Compiler
//It runs that, creates SyntaxNodes and constructs SyntaxTree, then I just run the tree, so basically execute, and that's flow.
namespace DataStructureLanguage.UserInterface
{
    public class CodeCanvas : MonoBehaviour
    {
        GameObject root;
        Compiler compiler;


        // Use this for initialization
        void Start()
        {
            root = transform.GetChild(0).gameObject;

            compiler = new Compiler(root.GetComponent<VisualNode>());

            /*UserController uc = GameObject.Find("UserController").GetComponent<UserController>();

            //Might turn compiler back into monobehaviour so can use coroutines for both scanning and executing, but we'll see
            uc.clickedCompile += () => { compiler.scan(); };
            uc.clickedStart += () => { compiler.execute(); };
            */
        }

        //Could either have it here with buttons mapped to these via inspector or check with the raycast touch stuff and execute as neccessarry
        //which adds more dynamicness so can add visuals or whatever as compiling, but could also just show it here.
        //Will leave like this for now.
        public void compile()
        {
            compiler.scan();
        }

        public void run()
        {
            if (!compiler.RunningCode)
                StartCoroutine(compiler.execute());
        }

        public void stop()
        {
            compiler.stopExecution();
        }

        //This will traverse from root to all visual nodes and removes them all.
        public void clear()
        {

        }
    }
}
