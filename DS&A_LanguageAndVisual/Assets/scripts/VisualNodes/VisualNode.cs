using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No instance of just visual node is possible, put in correct namespace later.
public abstract class VisualNode : MonoBehaviour {

    //Maybe make property later, do thiss, I forgot why needed but is important
    protected VisualNode prev, next;

    public virtual VisualNode Next
    {
        set
        {
            next = value;
        }
        get
        {
            return next;
        }
    }

    public virtual VisualNode Prev
    {
        set
        {
            prev = value;
        }
        get
        {
            return prev;
        }
    }

    //Representing kind of Visual Node
    string id;

    //I suppose IfElse prefab will just be GameObject with two GameObjects parented under it, an If and an Else Visual Node. Think that makes
    //most sense
    public string ID
    {
        get { return id; }
    
    }
}

