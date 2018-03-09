using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisual : VisualNode {

    //Head will always be BinaryOperationNode for condition or function sig.
    VisualNode head;
    //Scratch head has to be self.
    
    //Basically forcing state on these, now when would I reset current? I guess leave that up to develeoper
    //but that's for sure a design flaw.
    VisualNode current;
    VisualNode tail;

    //Don't need attribute for tailGraphic, just part of prefab


    // Use this for initialization
    void Start() {

        //Basically every VisualNode will traceback until they find BlockNode, then that's their scope.
        //Tbh it's only needed for Else, but I'll find other uses and it seems like would be useful for extending this later on
        head.Prev = this;

        head = current;
        tail = null;
    }

   
    public override VisualNode Next{

        set
        {
            //Have append method for adding onto inner list, then this would be actual next
            //But kinda seems fucked up, getting Next will not be same Next you are expecting
            //me overriding this makes it more streamlined, but at the cost of ambiguity, should I change it to next child instead?
            //Again this is semantics and causes only slight changes in code, but think latter is definitely better.
            next = value;
        }
        get
        {
            //Should Documentation just mention this?
            if (current.Next == null)
            {
                //Actully would I end up calling my own Next end up causing recursion, instead of calling base one, we'll see if this works
                //this definietly something to test in isolation
                return base.Next;
            }

            current = current.Next;
            return current;
        }
     }
	
    public VisualNode Head
    {
        get
        {
            return head;
        }
    }

    //So need to detect if touching head of block visual when do this is key point, update that in the UserController
    public void setHead(VisualNode visualNode)
    {
        //Can't put something that's not a value inside here
        if (visualNode is BlockVisual)
        {
            return;
        }

        if (head != null)
            visualNode.Next = head.Next;

        head = visualNode;

    }

	public void append(VisualNode node)
    {
        //Always start off at head's next
        VisualNode curr = head.Next;

        while (curr.Next != null)
        {
            curr = curr.Next;
        }

        curr.Next = node;
        node.Next = null;
    }

    //This is why I need to make method for Next, so that I can override it, this is definitely high on TODO

    //Have these already set, just change to nextChild to make explicit
    public VisualNode nextChild()
    {
        current = current.Next;
        return current;

    }

    public VisualNode prevChild()
    {
        current = current.Prev;
        return current;
    }

    public VisualNode CurrentNode
    {
        get
        {
            return current;
        }
    }
}
