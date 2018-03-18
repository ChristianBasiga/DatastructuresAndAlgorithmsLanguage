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
            compiler = new Compiler(root.GetComponent<BlockVisual>());
            root = transform.GetChild(0).gameObject;
            UserController uc = GameObject.Find("UserController").GetComponent<UserController>();

            //Might turn compiler back into monobehaviour so can use coroutines for both scanning and executing, but we'll see
            uc.clickedCompile += () => { compiler.scan(); };
            uc.clickedStart += () => { compiler.execute(); };

        }


        //This will traverse from root to all visual nodes and removes them all.
        public void clear()
        {

        }
    }
}
