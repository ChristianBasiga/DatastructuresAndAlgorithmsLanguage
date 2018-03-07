using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No instance of just visual node is possible, put in correct namespace later.
public abstract class VisualNode : MonoBehaviour {

    //Maybe make property later, fuck it for now.
    public VisualNode prev, next;

    List<int> lineNumbers;

    //Representing kind of Visual Node
    string id;

    public string ID
    {
        get { return id; }
    
    }


   


}

